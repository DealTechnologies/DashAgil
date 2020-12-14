using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ApiController
    {
        private readonly AuthHandler authHandler;
        public AuthController(AuthHandler authHandler)
        {
            this.authHandler = authHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthCommand command)
        {
            var response = await authHandler.Handle(command);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
