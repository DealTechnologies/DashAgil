using DashAgil.Integrador.Commands.Input;
using DashAgil.Integrador.Commands.Output;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Comum;
using DashAgil.Integrador.Repositorio;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Handlers
{
    public class IntegradorHandler : ICommandHandler<SalvarEstoriaCommand>,
                                     ICommandHandler<AtualizarProjetosCommand>,
                                     ICommandHandler<AtualizarTiposWorkItens>
    {
        private readonly IAzureDevopsRepository repository;

        public IntegradorHandler(IAzureDevopsRepository repository)
        {
            this.repository = repository;
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
            var projetosDevops = await repository.ObterProjetos(command.Organizacao);

            if(projetosDevops is null || !projetosDevops.Value.Any())
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

        public async Task<ICommandResult> Handle(AtualizarTiposWorkItens command)
        {
            var tipos = await repository.ObterWorkItensTypes(command.Organizacao, command.Time, command.Projeto);

            if (tipos is null || !tipos.Value.Any())
                return new IntegradorCommandResult(false, "falha ao tentar atualizar os tipos de work itens", null);

            var tiposWorkItens = tipos.Value.ToList().Select(x => new TiposWorkItensDevops
            {
                Nome = x.Name,
                Url = x.Url,
                WorkItemTypeId= x.Id

            }).ToList();

            repository.SalvarTiposWorkItens(tiposWorkItens);

            return new IntegradorCommandResult(true, "Tipos de work itens atualizados com sucesso", tiposWorkItens);
        }

        public void teste()
        {
            repository.test();
        }
    }
}
