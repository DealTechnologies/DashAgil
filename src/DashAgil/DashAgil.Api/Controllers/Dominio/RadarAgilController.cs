using DashAgil.Api.Controllers.Comum;
using DashAgil.Commands.Input.RadarAgil;
using DashAgil.Handlers;
using DashAgil.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Api.Controllers.Dominio
{
    [ApiController]
    [Route("[controller]")]
    public class RadarAgilController : ApiController
    {
        private readonly RadarAgilHandler _handler;
        private readonly IRadarAgilRepository _radarAgilRepository;
        public RadarAgilController(RadarAgilHandler handler, IRadarAgilRepository radarAgilRepository)
        {
            _handler = handler;
            _radarAgilRepository = radarAgilRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InserirRadarCommand command)
        {
            var response = await _handler.Handle(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string squadId)
        {
            var response = await _radarAgilRepository.Obter(squadId);
            return Ok(response);
        }
    }
}
