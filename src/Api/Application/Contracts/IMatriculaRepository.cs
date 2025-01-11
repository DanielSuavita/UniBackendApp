using Api.Domain;
using FluentResults;

namespace Api.Application.Contracts
{
    public interface IMatriculaRepository
    {
        Task<Result<bool>> Create(Matricula matricula);
        Task<Result<List<Matricula>>> GetMatriculas();
        Task<Result<List<AsignaturasMatricula>>> GetEstudiantesMatriculadosByAsignatura(AsignaturasMatricula asignaturasMatricula);
        Task<Result<PeriodoAcademico>> GetPeriodoAcademicoActivo();
    }
}