using Api.Infrastructure;
using Asp.Versioning;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace Api.IoC
{
    public static class ServiceDefaults
    {

        public static void ConfigureApi(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        }

        public static void UseMiddlewares(this WebApplication app)
        {
            app.MapHealthChecks("/api/Health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            });
        }

        public static void AddMiddlewares(this IServiceCollection services, IConfigurationManager configuration)
        {
            AddDatabasePersistence(services, configuration);
            AddApiVersioning(services);
            ConfigureHealthChecks(services, configuration);
        }
        private static void AddDatabasePersistence(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddDbContext<UniDatabaseContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Database"),
                    provideroptions => provideroptions.EnableRetryOnFailure()
                )
            );
        }
        private static void AddApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version")
                );
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "v'V";
                options.SubstituteApiVersionInUrl = true;
            });
        }
        private static void ConfigureHealthChecks(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database") ?? string.Empty);
        }
    }
}
