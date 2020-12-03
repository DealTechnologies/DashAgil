using DashAgil.Integrador.Api.Controllers.Comum;
using DashAgil.Integrador.Jira.Handlers;
using DashAgil.Integrador.Jira.Commands.Input.Integrador;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post(IntegracaoInicialCommand command)
        {
            var response = await _handler.Handle(command);
            return Ok(response);
        }


    }
}
