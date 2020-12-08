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

        [HttpGet("projetos")]
        public async Task<IActionResult> Projetos(AtualizarProjetosCommand command)
        {
            var result = await _handler.Handle(command);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("tipos-work-itens")]
        public async Task<IActionResult> TiposWorkItens([FromQuery] string organizacao, string projeto, string team)
        {
            var result = await _handler.Handle(new AtualizarTiposWorkItens { Organizacao = organizacao, Projeto = projeto, Time = team });

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        //public async Task<IActionResult> WorkItens([FromQuery] string organizacao)
        //{

        //}

    }
}