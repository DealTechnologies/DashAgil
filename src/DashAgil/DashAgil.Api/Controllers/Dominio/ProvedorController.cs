using DashAgil.Api.Controllers.Comum;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class ProvedorController : ApiController
    {
        private readonly ProvedorHandler handler;

        private readonly ILogger<VisaoGeralController> _logger;

        public ProvedorController(ILogger<VisaoGeralController> logger, ProvedorHandler handler)
        {
            _logger = logger;
            this.handler = handler;
        }

        [HttpGet]
        [Route("ObterProvedores")]
        public async Task<IActionResult> ObterProvedores()
        {
            var response = await handler.Handle();
            return Ok(response);
        }        
    }
}
