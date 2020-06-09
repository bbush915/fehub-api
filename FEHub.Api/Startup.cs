//-----------------------------------------------------------------------------
// <copyright file="Startup.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Api.GraphQL;
using FEHub.Entity;

using GraphQL.Server;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FEHub.Api
{
    internal sealed class Startup
    {
        #region Constructors
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        #endregion

        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<FehContextFactory>();
            services.AddSingleton<FehSchema>();
            
            services
                .AddGraphQL()
                .AddGraphTypes(typeof(FehSchema))
                .AddSystemTextJson()
                .AddUserContextBuilder((httpContext) => new FehUserContext() { User = httpContext.User })
                .AddDataLoader();

            services.AddCors(
                (configuration) =>
                {
                    configuration.AddPolicy(
                        "production",
                        (policyBuilder) =>
                        {
                            policyBuilder
                                .WithOrigins(
                                    Configuration.GetValue<string>("ProductionHost")
                                )
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    );

                    configuration.AddPolicy(
                        "default",
                        (policyBuilder) =>
                        {
                            policyBuilder
                                .WithOrigins("http://localhost:5000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    );
                }
            );
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
                
            applicationBuilder.UseCors(
                webHostEnvironment.IsDevelopment() 
                    ? "default" 
                    : "production"
            );

            applicationBuilder.UseGraphQL<FehSchema>();

            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseGraphQLPlayground();
                applicationBuilder.UseGraphQLVoyager();
            }
        }
        #endregion
    }
}
