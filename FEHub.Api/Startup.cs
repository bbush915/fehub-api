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

        public IWebHostEnvironment Environment { get; }
        #endregion

        #region Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<FehContextFactory>();

            services
                .AddSingleton<FehSchema>()
                .AddGraphQL()
                .AddSystemTextJson()
                .AddUserContextBuilder((httpContext) => new FehUserContext() { User = httpContext.User })
                .AddDataLoader()
                .AddGraphTypes(typeof(FehSchema));

            services.AddCors(
                (configuration) =>
                {
                    configuration.AddDefaultPolicy(
                        (policyBuilder) =>
                        {
                            policyBuilder
                                .AllowAnyOrigin()
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

            applicationBuilder.UseCors();

            applicationBuilder.UseGraphQL<FehSchema>();
            applicationBuilder.UseGraphQLPlayground();
            applicationBuilder.UseGraphQLVoyager();

            applicationBuilder.UseStaticFiles();
        }
        #endregion
    }
}
