using Api.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetProfesorByAsignatura
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetProfesorByAsignaturaController : ControllerBase
    {
        private readonly IProfesorRepository _Repository;

        public GetProfesorByAsignaturaController(IProfesorRepository repository)
        {
            _Repository = repository;
        }

        // GET api/<GetProfesorByAsignaturaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> HandleAsync(int id)
        {
            var Result = await _Repository.GetProfesorByAsignatura(id);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
