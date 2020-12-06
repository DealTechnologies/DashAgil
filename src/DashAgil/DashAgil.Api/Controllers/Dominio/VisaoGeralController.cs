using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class VisaoGeralController : ApiController
    {
        private readonly VisaoGeralHandler handler;

        private readonly ILogger<VisaoGeralController> _logger;

        public VisaoGeralController(ILogger<VisaoGeralController> logger, VisaoGeralHandler handler)
        {
            _logger = logger;
            this.handler = handler;
        }

        [HttpGet]
        [Route("ObterVisaoGeralDemandas")]
        public async Task<IActionResult> ObterVisaoGeralDemandas(ObterVisaoGeralDemandasCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("ObterVisaoGeralFeatures")]
        public async Task<IActionResult> ObterVisaoGeralFeatures(ObterVisaoGeralFeaturesCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SalvarEstoriaCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }
    }
}
