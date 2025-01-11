using Api.Application.Contracts;
using Api.Domain;
using Api.Infrastructure;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly UniDatabaseContext _Context;

        public MatriculaRepository(UniDatabaseContext Context)
        {
            _Context = Context;
        }

        public async Task<Result<bool>> Create(Matricula matricula)
        {
            if (matricula.AsignaturasMatriculas.Count == 0)
            {
                return new Error("No se envió ninguna Asignatura");
            }

            if (matricula.AsignaturasMatriculas.Count > 3)
            {
                return new Error("Se enviaron demasiadas Asignaturas para Matricular");
            }

            if (matricula.AsignaturasMatriculas.GroupBy(x => x.IdProfesor).Any(y => y.Count() > 1))
            {
                return new Error("No se puede matricular más de una asignatura con el mismo profesor");
            }

            await _Context.Matriculas.AddAsync(matricula);
            await _Context.SaveChangesAsync();

            await _Context.Creditos
                    .Where(x => x.IdUsuario == matricula.IdEstudiante)
                    .ExecuteUpdateAsync(x => 
                        x.SetProperty(c => c.Cantidad, c => c.Cantidad - matricula.CreditosInscritos)
                    );

            return Result.Ok(true);
        }

        public async Task<Result<List<Matricula>>> GetMatriculas()
        {
            var Matriculas = await _Context.Matriculas.ToListAsync();

            return Result.Ok(Matriculas);
        }

        public async Task<Result<List<AsignaturasMatricula>>> GetEstudiantesMatriculadosByAsignatura(AsignaturasMatricula asignaturasMatricula)
        {
            var EstudiantesByAsignatura = await _Context.AsignaturasMatriculas
                .Where(x => x.IdAsignatura == asignaturasMatricula.IdAsignatura && x.IdProfesor == asignaturasMatricula.IdProfesor)
                .Include(a => a.IdAsignaturaNavigation)
                .Include(m => m.IdMatriculaNavigation)
                .ThenInclude(e => e.IdEstudianteNavigation)
                .ToListAsync();

            return Result.Ok(EstudiantesByAsignatura);
        }

        public async Task<Result<PeriodoAcademico>> GetPeriodoAcademicoActivo()
        {
            var PeriodoAcademicoActivo = await _Context.PeriodoAcademicos.Where(x => x.Activo).FirstOrDefaultAsync();

            return Result.Ok(PeriodoAcademicoActivo);
        }
    }
}
