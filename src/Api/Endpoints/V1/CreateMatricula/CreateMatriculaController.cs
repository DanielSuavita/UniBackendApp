using Api.Application.Contracts;
using Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.CreateMatricula
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class CreateMatriculaController : ControllerBase
    {
        private readonly IMatriculaRepository _Repository;

        public CreateMatriculaController(IMatriculaRepository repository)
        {
            _Repository = repository;
        }

        // POST api/<CreateMatriculaController>
        [HttpPost]
        public async Task<IActionResult> HandleAsync(CreateMatriculaRequest Request)
        {
            if (Request.AsignaturasMatriculas.Count == 0)
            {
                return BadRequest();
            }

            var Matricula = new Matricula
            {
                IdEstudiante = Request.IdEstudiante,
                IdPeriodoAcademico = Request.IdPeriodoAcademico,
                CreditosInscritos = Request.CreditosInscritos,
            };

            foreach (var Asignatura in Request.AsignaturasMatriculas) {
                Matricula.AsignaturasMatriculas.Add(new AsignaturasMatricula
                {
                    IdAsignatura = Asignatura.IdAsignatura,
                    IdProfesor = Asignatura.IdProfesor,
                });
            }

            var Result = await _Repository.Create(Matricula);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result);
        }
    }
}
