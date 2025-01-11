using Api.Domain;
using FluentResults;

namespace Api.Application.Contracts
{
    public interface IEstudianteRepository
    {
        Task<Result<List<AsignaturasMatricula>>> GetAsignaturasByEstudiante(int IdEstudiante);
    }
}