using DashAgil.Commands.Input.VisaoGeral;
using DashAgil.Commands.Output;
using DashAgil.Commands.Output.VisaoGeral;
using DashAgil.Entidades;
using DashAgil.Enums;
using DashAgil.Infra.Comum;
using DashAgil.Queries;
using DashAgil.Repositorio;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class VisaoGeralHandler : ICommandHandler<ObterVisaoGeralDemandasCommand>,
        ICommandHandler<ObterVisaoGeralFeaturesCommand>,
        ICommandHandler<ObterListaEstoriasPorSquadCommand>,
        ICommandHandler<ObterVisaoEstoriasPorSquadCommand>,
        ICommandHandler<ObterVelocidadePorSquadCommand>
    {
        protected readonly IDemandaRepository _repository;
        public VisaoGeralHandler(IDemandaRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICommandResult> Handle(ObterVisaoGeralDemandasCommand command)
        {
            var demandas = await _repository.GetDemandas(command.IdCliente, (int)EDemandaTipo.UserStory, command.IdUsuario);
            var demanda = new Demandas();
            var squad = new Squads();

            var visaoCommandResult = new ObterVisaoGeralDemandasCommandResult
            {
                ListaEstoriasPorEstagio = demanda.TotalEstoriasPorEstagio(demandas),
                ListaEstoriasPorSquad = demanda.TotalEstoriasPorSquad(demandas),
                TotalGeralEstorias = demanda.TotalGeralEstorias(demandas),
                ListaEvolucaoSquad = squad.EvolucaoSquad(demandas)
            };

            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", visaoCommandResult);
        }

        public async Task<ICommandResult> Handle(ObterVisaoGeralFeaturesCommand command)
        {
            var featuresEstorias = await _repository.GetFeaturesEstorias(command.IdCliente, command.IdSquad, command.IdUsuario);
            var demanda = new Demandas();
            var sprint = new Sprints();

            var historicoEstorias = await _repository.GetEstoriasHistorico(command.IdCliente, command.IdSquad, command.IdSprint, command.IdUsuario);
            //var visaoFeaturesResult = new ObterVisaoGeralFeaturesCommandResult
            //{
            //    ListaFeaturesEstagio = demanda.TotalEstoriasPorFeature(featuresEstorias),                
            //    SprintBurndown = sprint.Burndown(historicoEstorias, command.IdSprint)
            //};

            var listaPercentual = new ListDictionary();
            listaPercentual.Add("PercentualFeaturesHomologacao", demanda.PercentualFeaturesHomologacao(featuresEstorias));
            listaPercentual.Add("PercentualFeaturesConclusao", demanda.PercentualFeaturesConcluisao(featuresEstorias));

            dynamic retorno = new ExpandoObject();
            retorno.ListaFeaturesEstagio = demanda.TotalEstoriasPorFeature(featuresEstorias);
            retorno.SprintBurndown = sprint.Burndown(historicoEstorias, command.IdSprint);
            retorno.ListaPercentual = listaPercentual;

            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", retorno);
        }

        public async Task<ICommandResult> Handle(ObterListaEstoriasPorSquadCommand command)
        {
            var estorias = await _repository.GetAll(command.IdCliente, (int)EDemandaTipo.UserStory, command.IdUsuario, command.IdSquad);
            var demanda = new Demandas();
            
            var listaDemandasResult = new ObterListaEstoriasPorSquadCommandResult {
                ListaDemandas = demanda.TratamentoListaEstorias(estorias)
            };

            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", listaDemandasResult);
        }

        public async Task<ICommandResult> Handle(ObterVisaoEstoriasPorSquadCommand command)
        {
            var estorias = await _repository.GetDemandas(command.IdCliente, (int)EDemandaTipo.UserStory, command.IdUsuario);
            var squads = estorias.GroupBy(x => x.Squad.Nome).Select(y => y.First().Squad.Nome).ToList();
            var result = new List<SquadItensQueryResult>();

            foreach (var squad in squads)
            {
                var itens = estorias.Where(x => x.Squad.Nome.Equals(squad)).ToList();
                var squadResult = SquadItensQueryResult.ObterTotais(itens, squad);

                result.Add(squadResult);

            }

            var total = SquadItensQueryResult.ObterTotais(estorias.ToList(), "Total Geral");
            result.Add(total);

            return new GenericCommandResult(true, "sucess", result);
        }

        public async Task<ICommandResult> Handle(ObterVelocidadePorSquadCommand command)
        {
            var estorias = await _repository.GetDemandasSprint(command.IdCliente, (int)EDemandaTipo.UserStory, command.IdSquad, command.IdUsuario);
            var demanda = new Demandas();
            var result = demanda.VelocidadePorSquad(estorias);

            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", result);
        }
    }
}
