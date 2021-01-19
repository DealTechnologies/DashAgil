using DashAgil.Commands.Input.VisaoGeral;
using DashAgil.Commands.Output;
using DashAgil.Commands.Output.VisaoGeral;
using DashAgil.Entidades;
using DashAgil.Enums;
using DashAgil.Infra.Comum;
using DashAgil.Queries;
using DashAgil.Repositorio;
using System;
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

            #region burndown

            var burndownResult = new SprintBurndown();

            if(historicoEstorias.Any())
            {
                burndownResult.Id = command.IdSprint;
                burndownResult.DataInicio = historicoEstorias.FirstOrDefault().SprintDataInicio;
                burndownResult.DataFim = historicoEstorias.FirstOrDefault().SprintDataFim;
                burndownResult.Nome = historicoEstorias.FirstOrDefault().SprintNome;



                int quantidadeDiasUteis = 0;
                var dataAux = burndownResult.DataInicio;

                while (dataAux.Date <= burndownResult.DataFim.Date)
                {

                    if (dataAux.DayOfWeek != DayOfWeek.Saturday && dataAux.DayOfWeek != DayOfWeek.Sunday)
                        quantidadeDiasUteis++;

                    dataAux = dataAux.AddDays(1);
                };


                var pontos = historicoEstorias.Sum(x => x.Pontos) ?? 0;
                var pontosPorDia = Convert.ToInt32(Math.Round(Convert.ToDecimal(pontos) / Convert.ToDecimal(quantidadeDiasUteis), 0));
                var pontosDesejados = pontos;
                dataAux = burndownResult.DataInicio;

                while (dataAux.Date <= burndownResult.DataFim.Date)
                {

                    var demandaHistorico = new DemandasHistoricos();
                    demandaHistorico.VelocidadeIdeal = pontosDesejados;
                    demandaHistorico.Dia = dataAux.Date;
                    if (dataAux.Date == burndownResult.DataFim.Date || pontosDesejados < 0)
                    {
                        demandaHistorico.VelocidadeIdeal = 0;
                    }

                    if (dataAux.DayOfWeek != DayOfWeek.Saturday && dataAux.DayOfWeek != DayOfWeek.Sunday)
                        pontosDesejados = pontosDesejados - pontosPorDia;

                    demandaHistorico.VelocidadeSprint = pontos - (historicoEstorias.Where(x => x.DataFim != null && x.DataFim <= dataAux.AddDays(1).Date).Sum(y => y.Pontos) ?? 0);

                    burndownResult.DemandasHistoricos.Add(demandaHistorico);

                    dataAux = dataAux.AddDays(1);
                };
            }
            #endregion


            var listaPercentual = new ListDictionary();
            listaPercentual.Add("PercentualFeaturesHomologacao", demanda.PercentualFeaturesHomologacao(featuresEstorias));
            listaPercentual.Add("PercentualFeaturesConclusao", demanda.PercentualFeaturesConcluisao(featuresEstorias));

            dynamic retorno = new ExpandoObject();
            retorno.ListaFeaturesEstagio = demanda.TotalEstoriasPorFeature(featuresEstorias);

            if (historicoEstorias.Any())
                retorno.SprintBurndown = burndownResult;
            else
            retorno.SprintBurndown = sprint.Burndown(historicoEstorias, command.IdSprint);

            retorno.ListaPercentual = listaPercentual;

            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", retorno);
        }

        public async Task<ICommandResult> Handle(ObterListaEstoriasPorSquadCommand command)
        {
            var estorias = await _repository.GetAll(command.IdCliente, (int)EDemandaTipo.UserStory, command.IdUsuario, command.IdSquad);
            var demanda = new Demandas();

            var listaDemandasResult = new ObterListaEstoriasPorSquadCommandResult
            {
                ListaDemandas = demanda.TratamentoListaEstorias(estorias)
            };

            await Task.CompletedTask;

            return new GenericCommandResult(true, "sucess", listaDemandasResult);
        }

        public async Task<ICommandResult> Handle(ObterVisaoEstoriasPorSquadCommand command)
        {

            if (!command.EhValido())
            {
                return new GenericCommandResult(false, "Erro", command.Notifications);
            }


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
