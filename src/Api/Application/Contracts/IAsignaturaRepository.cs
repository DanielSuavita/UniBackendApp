using Api.Domain;
using FluentResults;

namespace Api.Application.Contracts
{
    public interface IAsignaturaRepository
    {
        Task<Result<List<Asignatura>>> GetAll();
    }
}