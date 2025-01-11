using Api.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetAsignaturasByProfesor
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetAsignaturasByProfesorController : ControllerBase
    {
        private readonly IProfesorRepository _Repository;

        public GetAsignaturasByProfesorController(IProfesorRepository repository)
        {
            _Repository = repository;
        }

        // GET api/<GetAsignaturasByProfesorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> HandleAsync(int id)
        {
            var Result = await _Repository.GetAsignaturasByProfesor(id);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
