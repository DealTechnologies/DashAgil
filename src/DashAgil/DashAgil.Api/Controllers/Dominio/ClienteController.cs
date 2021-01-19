using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input.Cliente;
using DashAgil.Entidades;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        [HttpPost]
        public async Task Post()
        {
            var email = new SendMail();

            var json = JsonSerializer.Serialize(email);

            var client = new HttpClient();

            var response = await client.PostAsync("http://dashagilemail-env.eba-iiqkheny.sa-east-1.elasticbeanstalk.com/DashAgil", new StringContent(json, Encoding.UTF8, "application/json"));

            var statuss = response.StatusCode;

        }
    }
}
