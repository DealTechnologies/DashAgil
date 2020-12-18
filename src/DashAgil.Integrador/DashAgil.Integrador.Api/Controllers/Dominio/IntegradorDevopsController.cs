using DashAgil.Integrador.Api.Controllers.Comum;
using DashAgil.Integrador.Commands.Input;
using DashAgil.Integrador.Handlers;
using DashAgil.Integrador.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Api.Controllers.Dominio
{
    [ApiController]
    [Route("v1/devops")]
    public class IntegradorDevopsController : ApiController
    {
        private readonly IntegradorHandler _handler;

        public IntegradorDevopsController(IntegradorHandler _handler)
        {
            this._handler = _handler;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> Projetos([FromBody] IntegracaoInicialDevopsCommand command)
        {
            var result = await _handler.Handle(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("tipos-work-itens")]
        public async Task<IActionResult> TiposWorkItens([FromQuery] string organizacao, string projeto, string team)
        {
            var result = await _handler.Handle(new AtualizarTiposWorkItensCommand { Organizacao = organizacao, Projeto = projeto, Time = team });

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("atualizar-demandas")]
        public async Task<IActionResult> WorkItens([FromQuery] string organizacao)
        {
            var result = await _handler.Handle(new ObterWorkItensSumarizadoCommand { Organizacao = organizacao });

            if (!result.Success)
                return BadRequest(result);

            return Ok();
        }

    }
}