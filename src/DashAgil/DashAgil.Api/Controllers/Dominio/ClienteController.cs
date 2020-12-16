using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input.Cliente;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ApiController
    {
        private readonly ClienteHandler handler;

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger, ClienteHandler handler)
        {
            _logger = logger;
            this.handler = handler;
        }

        [HttpGet]
        [Route("ObterClientesPorProvedor")]
        public async Task<IActionResult> ObterClientesPorProvedor([FromQuery] ObterClientesPorProvedorCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }        
    }
}
