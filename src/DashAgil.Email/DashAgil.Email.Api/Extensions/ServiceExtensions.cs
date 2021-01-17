using DashAgil.Email.Infra.Data.Context;
using DashAgil.Email.Infra.Data.Repositorio;
using DashAgil.Email.Infra.Data.Settings;
using DashAgil.Email.Repositorio;
using DashAgil.Handlers;
using DashAgil.Infra.Data.Context;
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
            services.AddTransient<AwsContext, AwsContext>();

            services.Configure<AwsSettings>(configuration.GetSection("AwsSettings"));
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<EmailHandler, EmailHandler>();
        }

        /// <summary>
        /// The register service.
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISesRepositorio, SesRepositorio>();
            services.AddTransient<IEmailRepositorio, EmailRepositorio>();
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
