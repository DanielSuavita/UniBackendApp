using Api.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetAsignaturasByEstudiante
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetAsignaturaByEstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository _Repository;

        public GetAsignaturaByEstudianteController(IEstudianteRepository estudianteRepository)
        {
            _Repository = estudianteRepository;
        }

        // GET api/<GetAsignaturaByEstudianteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> HandleAsync(int id)
        {
            var Result = await _Repository.GetAsignaturasByEstudiante(id);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
