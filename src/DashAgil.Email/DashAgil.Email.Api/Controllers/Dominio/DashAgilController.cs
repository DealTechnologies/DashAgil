using Amazon.SimpleNotificationService.Util;
using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input;
using DashAgil.Email.Commands.Input;
using DashAgil.Email.Repositorio;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class DashAgilController : ApiController
    {
        private readonly EmailHandler handler;

        private readonly IEmailRepositorio emailRepositorio;

        private readonly ILogger<DashAgilController> logger;

        public DashAgilController(ILogger<DashAgilController> logger, IEmailRepositorio emailRepositorio, EmailHandler handler)
        {
            this.logger = logger;
            this.handler = handler;
            this.emailRepositorio = emailRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAsync() =>
            Ok(await this.emailRepositorio.ListarAsync());

        [HttpGet("Count")]
        public async Task<IActionResult> CountAsync() =>
            Ok(await this.emailRepositorio.ObterCountAsync());

        [HttpPost]
        public async Task<IActionResult> Post(EnviarEmailCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }

        [HttpPost("ReceiveNotifications")]
        public async Task<IActionResult> ReceiveNotifications()
        {
            if (Request.Body.CanRead)
            {
                using var reader = new StreamReader(Request.Body, Encoding.UTF8);

                var request = await reader.ReadToEndAsync();
                var message = Message.ParseMessage(request);

                //Debug
                //var request = System.Text.Json.JsonSerializer.Serialize(obj);

                logger.LogInformation(request);

                var result = await handler.Handle(new ReceiveNotificationCommand { Message = message });
                return Ok(result);
            }

            return Ok();
        }
    }
}
