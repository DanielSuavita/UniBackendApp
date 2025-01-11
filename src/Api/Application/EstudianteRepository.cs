using Api.Application.Contracts;
using Api.Domain;
using Api.Infrastructure;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly UniDatabaseContext _Context;
        public EstudianteRepository(UniDatabaseContext Context)
        {
            _Context = Context;
        }

        public async Task<Result<List<AsignaturasMatricula>>> GetAsignaturasByEstudiante(int IdEstudiante)
        {
            var AsignaturasByEstudiante = await _Context.AsignaturasMatriculas
                .Where(x => x.IdMatriculaNavigation.IdEstudiante == IdEstudiante)
                .Include(a => a.IdAsignaturaNavigation)
                .Include(m => m.IdMatriculaNavigation)
                .ThenInclude(e => e.IdEstudianteNavigation)
                .ToListAsync();

            return Result.Ok(AsignaturasByEstudiante);
        }
    }
}
