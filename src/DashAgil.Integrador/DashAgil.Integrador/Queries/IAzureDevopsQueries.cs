using DashAgil.Integrador.Entidades.Devops;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Queries
{
    public interface IAzureDevopsQueries
    {
        Task<DevopsResult<ProjectsResult>> ObterProjetos(string organizacao, string token);
        Task<DevopsResult<WorkItensTypeResult>> ObterWorkItensTypes(string organizacao, string time, string projeto, string token);
        Task<DevopsResult<QueryResult>> ConsultarPorQuery(string organizacao, string token);
        Task<DevopsResult<WorkItemResult>> GetWorkItemByURL(string url, string organizacao, string token);
    }
}
