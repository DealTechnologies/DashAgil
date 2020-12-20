using DashAgil.Api.Controllers.Comum;
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
        private readonly ISprintRepository _repo;

        private readonly ILogger<SprintController> _logger;

        public SprintController(ILogger<SprintController> logger, ISprintRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        [Route("Squad/{squadId}")]
        public async Task<IActionResult> ObterSprintsPorSquad(int squadId)
        {
            return Ok(await _repo.GetAllBySuqad(squadId));
        }

        [HttpGet("{sprintId}")]
        public async Task<Sprints> ObterSprntPorId([FromRoute] long sprintId)
        {
            return await _repo.GetSprintById(sprintId);
        }
    }
}
