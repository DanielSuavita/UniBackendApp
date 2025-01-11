using Api.Application;
using Api.Application.Contracts;

namespace Api.IoC
{
    public static class DependencyContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAsignaturaRepository, AsignaturaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<IProfesorRepository, ProfesorRepository>();
        }
    }
}
