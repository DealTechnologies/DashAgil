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
        ICommandHandler<ObterVisaoGeralFeaturesCommand>,
        ICommandHandler<ObterListaEstoriasPorSquadCommand>,
        ICommandHandler<ObterVisaoEstoriasPorSquadCommand>
    {
        protected readonly IDemandaRepository _repository;
        public VisaoGeralHandler(IDemandaRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(ObterVisaoGeralDemandasCommand command)
        {
            var demandas = await _repository.GetDemandas(command.IdProjeto, (int)EDemandaTipo.UserStory);
            var demanda = new Demanda();
            var squad = new Squad();

            var visaoCommandResult = new ObterVisaoGeralDemandasCommandResult
            {
                ListaEstoriasPorEstagio = demanda.TotalEstoriasPorEstagio(demandas),
                ListaEstoriasPorSquad = demanda.TotalEstoriasPorSquad(demandas),
                TotalGeralEstorias = demanda.TotalGeralEstorias(demandas),
                ListaEvolucaoSquad = squad.EvolucaoSquad(demandas)
            };

            await Task.CompletedTask;

            return new DemandaCommandResult(true, "sucess", visaoCommandResult);
        }

        public async Task<ICommandResult> Handle(ObterVisaoGeralFeaturesCommand command)
        {
            var featuresEstorias = await _repository.GetFeaturesEstorias(command.IdProjeto, command.IdSquad);
            var demanda = new Demanda();
            var sprint = new Sprint();

            var historicoEstorias = await _repository.GetEstoriasHistorico(command.IdProjeto, command.IdSquad, command.IdSprint);
            var visaoFeaturesResult = new ObterVisaoGeralFeaturesCommandResult
            {
                ListaFeaturesEstagio = demanda.TotalEstoriasPorFeature(featuresEstorias),
                PercentualFeaturesHomologacao = demanda.PercentualFeaturesHomologacao(featuresEstorias),
                SprintBurndown = sprint.Burndown(historicoEstorias, command.IdSprint)
            };

            await Task.CompletedTask;

            return new DemandaCommandResult(true, "sucess", visaoFeaturesResult);
        }

        public async Task<ICommandResult> Handle(ObterListaEstoriasPorSquadCommand command)
        {
            var estorias = await _repository.GetAll(command.IdProjeto, (int)EDemandaTipo.UserStory, int.Parse(command.IdSquad));
            var demanda = new Demanda();
            
            var listaDemandasResult = new ObterListaEstoriasPorSquadCommandResult {
                ListaDemandas = demanda.TratamentoListaEstorias(estorias)
            };

            await Task.CompletedTask;

            return new DemandaCommandResult(true, "sucess", listaDemandasResult);
        }

        public async Task<ICommandResult> Handle(ObterVisaoEstoriasPorSquadCommand command)
        {
            var estorias = await _repository.GetDemandas(command.IdProjeto, (int)EDemandaTipo.UserStory);
            var demanda = new Demanda();
            var listaEstoriasCommandResult = new ObterVisaoEstoriasPorSquadCommandResult
            {
                ListaEstoriasSquadEstagio = demanda.TotalEstoriasPorEstagioSquad(estorias)
            };

            await Task.CompletedTask;

            return new DemandaCommandResult(true, "sucess", listaEstoriasCommandResult);
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
