using Api.Application.Contracts;
using Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.V1.DeleteUsuario
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class DeleteUsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _Repository;

        public DeleteUsuarioController(IUsuarioRepository repository)
        {
            _Repository = repository;
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _Repository.Delete(id);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result);
        }
    }
}
