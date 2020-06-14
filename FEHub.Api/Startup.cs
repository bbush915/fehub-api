//-----------------------------------------------------------------------------
// <copyright file="Startup.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Linq;

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
            FehContextFactory.ConnectionString = this.Configuration.GetConnectionString("FEHub");

            services.AddSingleton<FehContextFactory>();
            
            services
                .AddSingleton<FehSchema>()
                .AddGraphQL()
                .AddGraphTypes(typeof(FehSchema))
                .AddSystemTextJson()
                .AddDataLoader();

            services.AddCors(
                (configuration) =>
                {
                    configuration.AddPolicy(
                        "default",
                        (policyBuilder) =>
                        {
                            policyBuilder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    );

                    configuration.AddPolicy(
                        "production",
                        (policyBuilder) =>
                        {
                            policyBuilder
                                .WithOrigins(this.Configuration.GetValue<string>("AllowedHosts").Split(";").Select(x => $"http://{x}").ToArray())
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
            applicationBuilder.UseGraphQLPlayground();

            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseGraphQLVoyager();
            }
        }
        #endregion
    }
}
