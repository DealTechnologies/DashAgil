using DashAgil.Integrador.Handlers;
using DashAgil.Integrador.Infra.Data;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Infra.Data.Repositorio;
using DashAgil.Integrador.Infra.HTTP;
using DashAgil.Integrador.Jira.Handlers;
using DashAgil.Integrador.Jira.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DashAgil.Integrador.Api.Extensions
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
            services.AddTransient<DataContext, DataContext>(provider => new DataContext(configuration.GetConnectionString("ConnectionString")));
            services.Configure<AppSettings>(options => configuration.GetSection("AppSettings").Bind(options));
            services.AddTransient<HttpService, HttpService>();
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IntegradorHandler, IntegradorHandler>();
            services.AddSingleton<IntegradorJiraHandler, IntegradorJiraHandler>();

            //services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            //services.AddSingleton<MonitorLoop>();
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            //services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            //services.AddSingleton<MonitorLoop>();
            services.AddSingleton<IBoardRepositorio, BoardRepositorio>();
            services.AddSingleton<IBacklogRepositorio, BacklogRepositorio>();
            

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
                        Title = "DashAgil Integrador API",
                        Description = "DashAgil Integrador API",
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
                c.DocumentTitle = "DashAgil Integrador API";
            });
        }

        #endregion
    }
}
