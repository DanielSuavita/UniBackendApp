using Api.Application.Contracts;
using Api.Domain;
using Api.Endpoints.V1.GetEstudiantesMatriculadosByAsignatura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetEstudiantesMatriculados
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetEstudiantesMatriculadosByAsignaturaController : ControllerBase
    {
        private readonly IMatriculaRepository _Repository;

        public GetEstudiantesMatriculadosByAsignaturaController(IMatriculaRepository repository)
        {
            _Repository = repository;
        }

        // GET: api/<GetEstudiantesMatriculadosByAsignaturaController>
        [HttpPost]
        public async Task<IActionResult> HandleAsync(GetEstudiantesMatriculadosByAsignaturaRequest Request)
        {
            if (Request == null)
            {
                return BadRequest();
            }

            var AsignaturasMatricula = new AsignaturasMatricula
            {
                IdAsignatura = Request.IdAsignatura,
                IdProfesor = Request.IdProfesor,
            };

            var Result = await _Repository.GetEstudiantesMatriculadosByAsignatura(AsignaturasMatricula);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
