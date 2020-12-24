using DashAgil.Integrador.Entidades.Devops;
using DashAgil.Integrador.Enums;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Queries
{
    public interface IAzureDevopsQueries
    {
        Task<DevopsResult<ProjectsResult>> ObterProjetos(string organizacao, string token);
        Task<DevopsResult<WorkItensTypeResult>> ObterWorkItensTypes(string organizacao, string time, string projeto, string token);
        Task<QueryResult> ConsultarPorQuery(string organizacao, string token, EQueryWorkItemType tipo);
        Task<string> GetWorkItemByURL(string url, string organizacao, string token);
        Task<string> GetWorkItemHistoric(string url, string organizacao, string token);
        Task<string> ObterWorkItemPorId(string organizacao, string projeto, string token, long workItenId);
        Task<DevopsResult<SprintResult>> ObterSprints(string organizacao, string projeto, string token, string team);
    }
}
