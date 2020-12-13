using DashAgil.Handlers;
using DashAgil.Infra.Data.Context;
using DashAgil.Infra.Data.Repositorio;
using DashAgil.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DashAgil.Api.Extensions
{
    public static class ServiceExtensions
    {
        #region Services

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DataContext, DataContext>(provider => new DataContext(configuration["ConnectionString:Connection"]));
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<DashAgilHandler, DashAgilHandler>();
            services.AddTransient<VisaoGeralHandler, VisaoGeralHandler>();
            services.AddTransient<ProvedorHandler, ProvedorHandler>();
            services.AddTransient<ClienteHandler, ClienteHandler>();
            services.AddTransient<SprintHandler, SprintHandler>();
            services.AddTransient<SquadHandler, SquadHandler>();

            //services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            //services.AddSingleton<MonitorLoop>();
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IDemandaRepository, DemandaRepository>();
            services.AddTransient<IProvedorRepository, ProvedorRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ISquadRepository, SquadRepository>();
            services.AddTransient<ISprintRepository, SprintRepository>();
            //services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            //services.AddSingleton<MonitorLoop>();
        }

        #endregion

        #region Swagger

        /// <summary>
        /// Adds the s to swagger.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static IServiceCollection AddSToSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "DashAgil API",
                        Description = "DashAgil API",
                    });
            });
        }

        /// <summary>
        /// The configure swagger.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public static void ConfigureSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.DocumentTitle = "DashAgil API";
            });
        }

        #endregion
    }
}
