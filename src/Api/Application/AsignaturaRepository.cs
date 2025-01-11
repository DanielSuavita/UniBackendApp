using Api.Application.Contracts;
using Api.Domain;
using Api.Infrastructure;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class AsignaturaRepository : IAsignaturaRepository
    {
        private readonly UniDatabaseContext _Context;
        public AsignaturaRepository(UniDatabaseContext Context)
        {
            _Context = Context;
        }

        public async Task<Result<List<Asignatura>>> GetAll()
        {
            var result = await _Context.Asignaturas.ToListAsync();
            return Result.Ok(result);
        }
    }
}
