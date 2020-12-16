using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input.Sprint;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class SprintController : ApiController
    {
        private readonly SprintHandler handler;

        private readonly ILogger<SprintController> _logger;

        public SprintController(ILogger<SprintController> logger, SprintHandler handler)
        {
            _logger = logger;
            this.handler = handler;
        }

        [HttpGet]
        [Route("ObterSprintsPorCliente")]
        public async Task<IActionResult> ObterSprintsPorCliente([FromQuery] ObterSprintsPorClienteCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }        
    }
}
