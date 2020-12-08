using DashAgil.Integrador.Commands.Input;
using DashAgil.Integrador.Commands.Output;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Queries;
using DashAgil.Integrador.Repositorio;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Handlers
{
    public class IntegradorHandler : ICommandHandler<SalvarEstoriaCommand>,
                                     ICommandHandler<AtualizarProjetosCommand>,
                                     ICommandHandler<AtualizarTiposWorkItensCommand>,
                                     ICommandHandler<ObterWorkItensSumarizadoCommand>
    {
        private readonly IAzureDevopsRepository repository;
        private readonly IAzureDevopsQueries _query;
        public IntegradorHandler(IAzureDevopsRepository repository, IAzureDevopsQueries query)
        {
            this.repository = repository;
            _query = query;
        }

        public async Task<ICommandResult> Handle(SalvarEstoriaCommand command)
        {
            var estoria = new Estoria(command.Nome, command.Descricao);

            //salvar
            var result = true;

            await Task.CompletedTask;

            return new IntegradorCommandResult(true, "sucess", result);
        }

        public async Task<ICommandResult> Handle(AtualizarProjetosCommand command)
        {
            var projetosDevops = await _query.ObterProjetos(command.Organizacao, command.Token);

            if (projetosDevops is null || !projetosDevops.Value.Any())
                return new IntegradorCommandResult(false, "falha ao tentar atualizar a base de projetos", null);

            var projetos = projetosDevops.Value.Select(x => new ProjetosDevops
            {
                DataUltimaAtualizacao = Convert.ToDateTime(x.LastUpdateTime),
                Descricao = x.Description,
                Nome = x.Name,
                ProjetoId = x.Id

            }).ToList();

            repository.SalvarProjetos(projetos);

            return new IntegradorCommandResult(true, "projetos atualizados com sucesso", projetos);
        }

        public async Task<ICommandResult> Handle(AtualizarTiposWorkItensCommand command)
        {
            string token = "";
            var tipos = await _query.ObterWorkItensTypes(command.Organizacao, command.Time, command.Projeto, token);

            if (tipos is null || !tipos.Value.Any())
                return new IntegradorCommandResult(false, "falha ao tentar atualizar os tipos de work itens", null);

            var tiposWorkItens = tipos.Value.ToList().Select(x => new TiposWorkItensDevops
            {
                Nome = x.Name,
                Url = x.Url,
                WorkItemTypeId = x.Id

            }).ToList();

            repository.SalvarTiposWorkItens(tiposWorkItens);

            return new IntegradorCommandResult(true, "Tipos de work itens atualizados com sucesso", tiposWorkItens);
        }

        public async Task<ICommandResult> Handle(ObterWorkItensSumarizadoCommand command)
        {
            string token = "";
            var result = await _query.ConsultarPorQuery(command.Organizacao, token);

            if (result is null || !result.Value.Any())
                return new IntegradorCommandResult(false, "falha ao tentar obter por query", command);
             

            return new IntegradorCommandResult(true, "Tipos de work itens atualizados com sucesso", null); 
        }

        public void teste()
        {
            repository.test();
        }
    }
}
