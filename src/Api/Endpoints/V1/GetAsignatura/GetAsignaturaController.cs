using Api.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetAsignatura
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetAsignaturaController : ControllerBase
    {
        private readonly IAsignaturaRepository _Repository;

        public GetAsignaturaController(IAsignaturaRepository Repository)
        {
            _Repository = Repository;
        }

        // GET api/<GetAsignaturaController>/5
        [HttpGet]
        public async Task<IActionResult> HandleAsync()
        {
            var Result = await _Repository.GetAll();

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
