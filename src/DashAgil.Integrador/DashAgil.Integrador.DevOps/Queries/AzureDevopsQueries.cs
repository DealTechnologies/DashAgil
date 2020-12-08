using DashAgil.Integrador.DevOps.Settings;
using DashAgil.Integrador.Entidades.Devops;
using DashAgil.Integrador.Queries;
using DashAgil.Integrador.Services;
using RestSharp;
using System.Threading.Tasks;

namespace DashAgil.Integrador.DevOps.Query
{
    public class AzureDevopsQueries : IAzureDevopsQueries
    {
        private readonly DevopsSettings _settings;

        public AzureDevopsQueries(DevopsSettings settings)
        {
            _settings = settings;
        }

        public async Task<DevopsResult<ProjectsResult>> ObterProjetos(string organizacao, string token)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.Projetos, organizacao);
            return await HTTPServices.DevopsRequest<DevopsResult<ProjectsResult>>(uri, token, organizacao);
        }

        public async Task<DevopsResult<QueryResult>> ConsultarPorQuery(string organizacao, string token)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.WorkItemByQuery, organizacao);
            return await HTTPServices.DevopsRequest<DevopsResult<QueryResult>>(uri, token, organizacao,
                                                                               new { query = _settings.Queries.AllWorkItens }, Method.POST);
        }

        public async Task<DevopsResult<WorkItensTypeResult>> ObterWorkItensTypes(string organizacao, string time, string projeto, string token)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.WorkItemTypes, organizacao, projeto, time);
            return await HTTPServices.DevopsRequest<DevopsResult<WorkItensTypeResult>>(uri, token, organizacao);
        }

        public async Task<DevopsResult<WorkItemResult>> GetWorkItemByURL(string url, string organizacao, string token)
        { 
            return await HTTPServices.DevopsRequest<DevopsResult<WorkItemResult>>(url, token, organizacao);
        }

        private string ObterTokenAutenticacao(string organizacao)
            => organizacao switch
            {
                "Corporativo" => _settings.CorporativoIds,
                _ => _settings.RendimentoId,
            };

    }
}
