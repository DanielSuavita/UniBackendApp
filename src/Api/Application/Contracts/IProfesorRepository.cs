using Api.Domain;
using FluentResults;

namespace Api.Application.Contracts
{
    public interface IProfesorRepository
    {
        Task<Result<List<AsignaturasProfesor>>> GetAsignaturasByProfesor(int IdProfesor);
        Task<Result<List<AsignaturasProfesor>>> GetProfesorByAsignatura(int IdAsingatura);
    }
}