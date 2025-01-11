using Api.Application.Contracts;
using Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace Api.Endpoints.V1.Login
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _Repository;

        public LoginController(IUsuarioRepository repository)
        {
            _Repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> HandleAsync(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            var Result = await _Repository.Login(usuario);

            if (Result.Errors.Count > 0)
            {
                return BadRequest(Result.Errors);
            }

            return Ok(Result.Value);
        }
    }
}
