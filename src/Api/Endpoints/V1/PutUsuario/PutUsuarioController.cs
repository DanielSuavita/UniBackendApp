using Api.Application.Contracts;
using Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.PutUsuario
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class PutUsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _Repository;

        public PutUsuarioController(IUsuarioRepository repository)
        {
            _Repository = repository;
        }

        // PUT api/<PutUsuarioController>
        [HttpPut]
        public async Task<IActionResult> HandleAsync(PutUsuarioRequest Request)
        {
            if (Request == null)
            {
                return BadRequest();
            }

            var usuario = new Usuario
            {
                Id = Request.Id,
                Nombre = Request.Nombre,
                Documento = Request.Documento,
            };

            var Result = await _Repository.Update(usuario);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result);
        }
    }
}
