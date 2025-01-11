using Api.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.GetUsuario
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class GetUsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _Repository;

        public GetUsuarioController(IUsuarioRepository repository)
        {
            _Repository = repository;
        }

        // GET api/<GetUsuarioController>/5
        [HttpGet("{Documento}")]
        public async Task<IActionResult> Get(string Documento)
        {
            var Result = await _Repository.Get(Documento);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
