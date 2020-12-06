using DashAgil.Integrador.Api.Controllers.Comum;
using DashAgil.Integrador.Jira.Commands.Input.Integrador;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DashAgil.Integrador.Handlers;

namespace DashAgil.Integrador.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class IntegradorJiraController : ApiController
    {
        private readonly IntegradorJiraHandler _handler;
        public IntegradorJiraController(IntegradorJiraHandler integradorHandler)
        {
            _handler = integradorHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IntegracaoInicialJiraCommand command)
        {
            var response = await _handler.Handle(command);
            return Ok(response);
        }


    }
}
