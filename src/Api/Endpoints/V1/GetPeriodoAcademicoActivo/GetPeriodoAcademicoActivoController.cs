using Api.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetPeriodoAcademicoActivo
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetPeriodoAcademicoActivoController : ControllerBase
    {
        private readonly IMatriculaRepository _Repository;

        public GetPeriodoAcademicoActivoController(IMatriculaRepository repository)
        {
            _Repository = repository;
        }

        // GET api/<GetPeriodoAcademicoActivoController>
        [HttpGet]
        public async Task<IActionResult> HandleAsync()
        {
            var Result = await _Repository.GetPeriodoAcademicoActivo();

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
