using Api.Application.Contracts;
using Api.Domain;
using Api.Infrastructure;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly UniDatabaseContext _Context;

        public ProfesorRepository(UniDatabaseContext Context)
        {
            _Context = Context;
        }

        public async Task<Result<List<AsignaturasProfesor>>> GetAsignaturasByProfesor(int IdProfesor)
        {
            var AsignaturasByProfesores = await _Context.AsignaturasProfesors
                .Where(x => x.IdProfesor == IdProfesor)
                .Include(p => p.IdProfesorNavigation)
                .Include(a => a.IdAsignaturaNavigation)
                .ToListAsync();

            return Result.Ok(AsignaturasByProfesores);
        }

        public async Task<Result<List<AsignaturasProfesor>>> GetProfesorByAsignatura(int IdAsingatura)
        {
            var ProfesorByAsignatura = await _Context.AsignaturasProfesors
                .Where(x => x.IdAsignatura == IdAsingatura)
                .Include(p => p.IdProfesorNavigation)
                .ToListAsync();

            return Result.Ok(ProfesorByAsignatura);
        }
    }
}
