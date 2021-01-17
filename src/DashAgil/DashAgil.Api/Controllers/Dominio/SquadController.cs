using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input.Squad;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class SquadController : ApiController
    {
        private readonly SquadHandler handler;

        private readonly ILogger<SquadController> _logger;

        public SquadController(ILogger<SquadController> logger, SquadHandler handler)
        {
            _logger = logger;
            this.handler = handler;
        }

        [HttpGet]
        [Route("ObterSquadsPorCliente")]
        public async Task<IActionResult> ObterSquadsPorCliente([FromQuery] ObterSquadsPorClienteCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }        
    }
}
