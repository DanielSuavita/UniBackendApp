using Api.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetMatriculas
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetMatriculasController : ControllerBase
    {
        private readonly IMatriculaRepository _Repository;

        public GetMatriculasController(IMatriculaRepository repository)
        {
            _Repository = repository;
        }

        // GET api/<GetMatriculaByAsignaturaController>/5
        [HttpGet]
        public async Task<IActionResult> HandleAsync()
        {
            var Result = await _Repository.GetMatriculas();

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
