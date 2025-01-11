namespace Api.IoC
{
    public static class SecurityContainer
    {
        public static void ConfigureSecurity(this IServiceCollection services)
        {
            ConfigureSecurityPolices(services);
        }

        public static void UseSecurityConfiguration(this WebApplication services)
        {
            services.UseCors("CORS");
        }

        private static void ConfigureSecurityPolices(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CORS", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
        }

        
    }
}
