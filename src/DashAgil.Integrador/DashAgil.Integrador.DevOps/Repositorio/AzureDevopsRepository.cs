using Dapper;
using DashAgil.Integrador.DevOps.Queries;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Queries;
using DashAgil.Integrador.Repositorio;
using RestSharp;
using System.Collections.Generic;

namespace DashAgil.Integrador.DevOps.Repositorio
{
    public class AzureDevopsRepository : IAzureDevopsRepository
    {
        private readonly DataContext _context; 
        public AzureDevopsRepository(DataContext context)
        {
            _context = context; 
        }
        public void test()
        {
            _context.Connection.Execute("insert into demandas (Id, ExternalId, ClienteId, SquadId, Tipo, DemandaPaiId, DataInicio) values (UUID(), 3, 1, 1, 4, 'D50B631C-17B1-4FF7-BBB6-A067F8E548DE', now())");
        }
         
        public void SalvarProjetos(List<ProjetosDevops> projetos)
        {
            projetos.ForEach(async projeto =>

                await _context.Connection.ExecuteAsync(ProjetosDevopsQueries.Insert, new
                {
                    projeto.DataCadastro,
                    projeto.DataUltimaAtualizacao,
                    projeto.Descricao,
                    projeto.Id,
                    projeto.Nome,
                    projeto.ProjetoId
                })
            );
        }
         
        public void SalvarTiposWorkItens(List<TiposWorkItensDevops> tipos)
        {
            tipos.ForEach(async tipo => await _context.Connection.ExecuteAsync(TiposWorkItensDevopsQueries.Insert,
                        new { tipo.Id, tipo.Nome, tipo.Url, tipo.DataCadastro, tipo.WorkItemTypeId }));
        }
    }
}
