using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input;
using DashAgil.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class DashAgilController : ApiController
    {
        private readonly EmailHandler handler;

        private readonly ILogger<DashAgilController> _logger;

        public DashAgilController(ILogger<DashAgilController> logger, EmailHandler handler)
        {
            _logger = logger;
            this.handler = handler;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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
        public async Task<IActionResult> Post(EnviarEmailCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }
    }
}
