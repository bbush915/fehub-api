using FEHub.Api.GraphQL;
using FEHub.Api.Options;
using FEHub.Api.Services;
using FEHub.Api.Services.Interfaces;
using FEHub.Entity;

using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FEHub.Api
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
              (corsOptions) =>
                  corsOptions.AddDefaultPolicy(
                      (corsPolicyBuilder) =>
                          corsPolicyBuilder
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                  )
            );

            var connectionString = this.Configuration.GetConnectionString("FEHub");

            services.Configure<DatabaseOptions>(
                (databaseOptions) =>
                {
                    databaseOptions.ConnectionString = connectionString;
                }
            );

            services.AddDbContext<FehContext>(
                (dbContextOptionsBuilder) => 
                    dbContextOptionsBuilder.UseSqlServer(connectionString)
            );

            services.AddControllers();

            services.AddScoped<IAccessoryService, Services.Ado.AccessoryService>();
            services.AddScoped<IArtistService, Services.Ado.ArtistService>();
            services.AddScoped(typeof(IEnumerationService<>), typeof(EnumerationService<>));
            services.AddScoped<IHeroService, Services.Ado.HeroService>();
            services.AddScoped<IHeroSkillService, Services.Ado.HeroSkillService>();
            services.AddScoped<IHeroVoiceActorService, Services.Ado.HeroVoiceActorService>();
            services.AddScoped<IItemService, Services.Ado.ItemService>();
            services.AddScoped<ISkillMovementTypeService, Services.Ado.SkillMovementTypeService>();
            services.AddScoped<ISkillService, Services.Ado.SkillService>();
            services.AddScoped<ISkillWeaponEffectivenessService, Services.Ado.SkillWeaponEffectivenessService>();
            services.AddScoped<ISkillWeaponTypeService, Services.Ado.SkillWeaponTypeService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IVoiceActorService, Services.Ado.VoiceActorService>();

            services
                .AddGraphQL(
                    (builder) =>
                        builder
                            .AddSystemTextJson()
                            .AddSchema<FehSchema>()
                            .AddGraphTypes()
                            .AddDataLoader()
                );
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseCors();
            applicationBuilder.UseGraphQL<FehSchema>();
            applicationBuilder.UseGraphQLPlayground();
            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(
                (endpointRouteBuilder) =>
                {
                    endpointRouteBuilder.MapControllers();
                }
            );

            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
        }
    }
}
