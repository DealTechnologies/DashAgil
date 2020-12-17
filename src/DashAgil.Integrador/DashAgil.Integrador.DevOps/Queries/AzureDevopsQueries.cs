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

        public async Task<string> ObterWorkItemPorId(string organizacao, string projeto , string token, long workItenId)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.WorkItemById, organizacao, projeto, workItenId);
            return await HTTPServices.DevopsRequestContent(uri, token, organizacao);
        }

        public async Task<DevopsResult<ProjectsResult>> ObterProjetos(string organizacao, string token)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.Projetos, organizacao);
            return await HTTPServices.DevopsRequest<DevopsResult<ProjectsResult>>(uri, token, organizacao);
        }  

        public async Task<DevopsResult<WorkItensTypeResult>> ObterWorkItensTypes(string organizacao, string time, string projeto, string token)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.WorkItemTypes, organizacao, projeto, time);
            return await HTTPServices.DevopsRequest<DevopsResult<WorkItensTypeResult>>(uri, token, organizacao);
        }

        public async Task<string> GetWorkItemByURL(string url, string organizacao, string token)
        { 
            return await HTTPServices.DevopsRequestContent(url, token, organizacao);
        }

        private string ObterTokenAutenticacao(string organizacao)
            => organizacao switch
            {
                "Corporativo" => _settings.CorporativoIds,
                _ => _settings.RendimentoId,
            };
        private string ObterQueryPorTipo(Integrador.Enums.EQueryWorkItemType tipo)
            => tipo switch
            {
                Integrador.Enums.EQueryWorkItemType.Epic => _settings.Queries.AllEpics,
                Integrador.Enums.EQueryWorkItemType.Feature => _settings.Queries.AllFeatures,
                Integrador.Enums.EQueryWorkItemType.UserStory => _settings.Queries.AllUS,
                Integrador.Enums.EQueryWorkItemType.Task => _settings.Queries.AllTasks,
                _ => _settings.Queries.AllTasks,
            };

        public async Task<string> GetWorkItemHistoric(string url, string organizacao, string token)
        {
           return await HTTPServices.DevopsRequestContent(url, token, organizacao); 
        }

        public async Task<QueryResult> ConsultarPorQuery(string organizacao, string token, Integrador.Enums.EQueryWorkItemType tipo)
        {
            string uri = string.Format(_settings.EndPoints.URI + _settings.EndPoints.WorkItemByQuery, organizacao);
            return await HTTPServices.DevopsRequest<QueryResult>(uri, token, organizacao,
                                                                               new { query = ObterQueryPorTipo(tipo) }, Method.POST);
        }
    }
}
