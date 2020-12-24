using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input.Sprint;
using DashAgil.Entidades;
using DashAgil.Handlers;
using DashAgil.Repositorio;
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
        private readonly ISprintRepository _repo;

        private readonly ILogger<SprintController> _logger;

        public SprintController(ILogger<SprintController> logger, SprintHandler handler, ISprintRepository repo)
        {
            _logger = logger;
            this.handler = handler;
            _repo = repo;
        }

        [HttpGet]
        [Route("ObterSprintsPorCliente")]
        public async Task<IActionResult> ObterSprintsPorCliente([FromQuery] ObterSprintsPorClienteCommand command)
        {
            var response = await handler.Handle(command);
            return Ok(response);
        }


        [HttpGet("{sprintId}")]
        public async Task<Sprints> ObterSprntPorId([FromRoute] long sprintId)
        {
            return await _repo.GetSprintById(sprintId);
        }
    }
}
