using DashAgil.Commands.Input;
using DashAgil.Commands.Output;
using DashAgil.Entidades;
using DashAgil.Enums;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using System.Dynamic;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class VisaoGeralHandler : ICommandHandler<SalvarEstoriaCommand>,
        ICommandHandler<ObterVisaoGeralDemandasCommand>,
        ICommandHandler<ObterVisaoGeralFeaturesCommand>
    {
        protected readonly IDemandaRepository _repository;
        public VisaoGeralHandler(IDemandaRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(ObterVisaoGeralDemandasCommand command)
        {
            //var demandasEstagio = await _repository.GetTotalDemandasPorEstagio(command.IdCliente);
            //var demandasSquad = await _repository.GetTotalDemandasPorSquad(command.IdCliente);            
            var demandas = await _repository.GetDemandas(command.IdCliente, (int)EDemandaTipo.UserStory);

            var demanda = new Demanda();
            var demandasEstagio = demanda.TotalEstoriasPorEstagio(demandas);
            var demandasSquad = demanda.TotalEstoriasPorSquad(demandas);
            var demandasTotal = demanda.TotalGeralEstorias(demandas);

            dynamic objectResult = new ExpandoObject();
            objectResult.demandasPorEstagio = demandasEstagio;
            objectResult.demandasPorSquad = demandasSquad;
            objectResult.totalDemandas = demandasTotal;

            await Task.CompletedTask;

            return new DemandaCommandResult(true, "sucess", objectResult);
        }

        public async Task<ICommandResult> Handle(ObterVisaoGeralFeaturesCommand command)
        {
            //var demandasEstagio = await _repository.GetTotalDemandasPorEstagio(command.IdCliente);
            //var demandasSquad = await _repository.GetTotalDemandasPorSquad(command.IdCliente);            
            var demandas = await _repository.GetDemandas(command.IdCliente, (int)EDemandaTipo.Feature);

            var demanda = new Demanda();
            var demandasEstagio = demanda.TotalEstoriasPorEstagio(demandas);
            var demandasSquad = demanda.TotalEstoriasPorSquad(demandas);
            var demandasTotal = demanda.TotalGeralEstorias(demandas);

            dynamic objectResult = new ExpandoObject();
            objectResult.demandasPorEstagio = demandasEstagio;
            objectResult.demandasPorSquad = demandasSquad;
            objectResult.totalDemandas = demandasTotal;

            await Task.CompletedTask;

            return new DemandaCommandResult(true, "sucess", objectResult);
        }

        public async Task<ICommandResult> Handle(SalvarEstoriaCommand command)
        {
            //var estoria = new Demanda(command.Nome, command.Descricao);

            //salvar
            var result = true;

            await Task.CompletedTask;

            return new DashAgilCommandResult(true, "sucess", result);
        }
    }
}
