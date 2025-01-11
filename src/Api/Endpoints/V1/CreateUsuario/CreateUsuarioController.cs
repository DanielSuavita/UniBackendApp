using Api.Application.Contracts;
using Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.CreateUsuario
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class CreateUsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _Repository;

        public CreateUsuarioController(IUsuarioRepository repository)
        {
            _Repository = repository;
        }

        // POST api/<CreateUsuarioController>
        [HttpPost]
        public async Task<IActionResult> HandleAsync(CreateUsuarioRequest Request)
        {
            if (Request == null)
            {
                return BadRequest();
            }

            var Usuario = new Usuario
            {
                Nombre = Request.Nombre,
                Documento = Request.Documento,
            };

            var Result = await _Repository.Create(Usuario);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Request);
        }
    }
}
