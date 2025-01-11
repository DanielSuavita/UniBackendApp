using Api.IoC;
using System.Text.Json.Serialization;

namespace Api
{
    internal class Program
    {
        protected Program() { }

        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.ConfigureApi();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddMiddlewares(builder.Configuration);
            builder.Services.AddDependencies();
            builder.Services.ConfigureSecurity();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddlewares();

            app.UseSecurityConfiguration();

            app.Run();
        }
    }
}