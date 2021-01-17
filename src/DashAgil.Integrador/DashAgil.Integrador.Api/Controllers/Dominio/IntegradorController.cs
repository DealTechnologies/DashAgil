using DashAgil.Integrador.Api.Controllers.Comum;
using DashAgil.Integrador.Commands.Input;
using DashAgil.Integrador.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntegradorController : ApiController
    {
        private readonly IntegradorHandler handler;

        private readonly ILogger<IntegradorController> _logger;

        public IntegradorController(ILogger<IntegradorController> logger, IntegradorHandler handler)
        {
            _logger = logger;
            this.handler = handler;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("teste")]
        public IActionResult Teste()
        {
            handler.teste();
            return Ok();
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Post(SalvarEstoriaCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }
    }
}
