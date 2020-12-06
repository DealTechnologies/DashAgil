using DashAgil.Commands.Input;
using DashAgil.Commands.Output;
using DashAgil.Entidades;
using DashAgil.Enums;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using System.Collections.Generic;
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
            var demandas = await _repository.GetDemandas(command.IdProjeto, (int)EDemandaTipo.UserStory);

            var demanda = new Demanda();

            //foreach (var demandaAux in demandas)
            //{
            //    demanda.StatusDeXPara = demanda.ConverterEstoriasStatus(demandaAux.Status);
            //}

            dynamic objectResult = new ExpandoObject();
            objectResult.demandasPorEstagio = demanda.TotalEstoriasPorEstagio(demandas);
            objectResult.demandasPorSquad = demanda.TotalEstoriasPorSquad(demandas);
            objectResult.totalDemandas = demanda.TotalGeralEstorias(demandas);
            objectResult.evolucaoSquad = demanda.EvolucaoSquad(demandas);

            await Task.CompletedTask;

            return new DemandaCommandResult(true, "sucess", objectResult);
        }

        public async Task<ICommandResult> Handle(ObterVisaoGeralFeaturesCommand command)
        {
            //var demandasEstagio = await _repository.GetTotalDemandasPorEstagio(command.IdCliente);
            //var demandasSquad = await _repository.GetTotalDemandasPorSquad(command.IdCliente);            
            var featuresEstorias = await _repository.GetFeaturesEstorias(command.IdProjeto, command.IdSquad);

            var demanda = new Demanda();
            
            dynamic objectResult = new ExpandoObject();
            objectResult.featuresEstoriasPorEstagio = demanda.TotalEstoriasPorFeature(featuresEstorias);
            objectResult.featuresHomologacaoPercentual = demanda.PercentualFeaturesHomologacao(featuresEstorias);

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
