using Dapper;
using DashAgil.Integrador.DevOps.Queries;
using DashAgil.Integrador.DevOps.Settings;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Entidades.Devops;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using DashAgil.Integrador.Services;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashAgil.Integrador.DevOps.Repositorio
{
    public class AzureDevopsRepository : IAzureDevopsRepository
    {
        private readonly DataContext _context;
        private readonly DevopsSettings _settings;
        public AzureDevopsRepository(DataContext context, DevopsSettings devopsSettings)
        {
            _context = context;
            _settings = devopsSettings;
        }
        public void test()
        {
            _context.Connection.Execute("insert into demandas (Id, ExternalId, ClienteId, SquadId, Tipo, DemandaPaiId, DataInicio) values (UUID(), 3, 1, 1, 4, 'D50B631C-17B1-4FF7-BBB6-A067F8E548DE', now())");
        }

        public async Task<DevopsResult<Projects>> ObterProjetos(string organizacao)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.Projetos, organizacao);
            return await HTTPServices.DevopsRequest<DevopsResult<Projects>>(uri, ObterTokenAutenticacao(organizacao), organizacao);
        }

        public async Task<DevopsResult<QueryResult>> ConsultarPorQuery(string organizacao)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.WorkItemByQuery, organizacao);
            return await HTTPServices.DevopsRequest<DevopsResult<QueryResult>>(uri, ObterTokenAutenticacao(organizacao), organizacao, 
                                                                               new { query = _settings.Queries.AllWorkItens }, Method.POST);

        }


        private string ObterTokenAutenticacao(string organizacao)
            => organizacao switch
            {
                "Corporativo" => _settings.CorporativoIds,
                _ => _settings.RendimentoId,
            };

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

        public async Task<DevopsResult<WorkItensType>> ObterWorkItensTypes(string organizacao, string time, string projeto)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.WorkItemTypes, organizacao, projeto, time);
            return await HTTPServices.DevopsRequest<DevopsResult<WorkItensType>>(uri, ObterTokenAutenticacao(organizacao), organizacao);
        }

        public void SalvarTiposWorkItens(List<TiposWorkItensDevops> tipos)
        {
            tipos.ForEach(async tipo => await _context.Connection.ExecuteAsync(TiposWorkItensDevopsQueries.Insert, 
                        new { tipo.Id, tipo.Nome, tipo.Url, tipo.DataCadastro, tipo.WorkItemTypeId }));
        }
    }
}
