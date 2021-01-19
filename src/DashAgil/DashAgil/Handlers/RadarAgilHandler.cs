using DashAgil.Commands.Input.RadarAgil;
using DashAgil.Commands.Output;
using DashAgil.Entidades;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class RadarAgilHandler : ICommandHandler<InserirRadarCommand>
    {
        private readonly IRadarAgilRepository _radarAgilRepository;
        public RadarAgilHandler(IRadarAgilRepository radarAgilRepository)
        {
            _radarAgilRepository = radarAgilRepository;
        }

        public async Task<ICommandResult> Handle(InserirRadarCommand command)
        {
            if(!command.EhValido())
                return new DashAgilCommandResult(false, "Não foi possível salvar o radar", command.Notifications);

            var radar = RadarAgil.PreencherRadar(command);

            await _radarAgilRepository.Inserir(radar);

            return new DashAgilCommandResult(true, "Radar inserido com sucesso", command);
        }
    }
}
