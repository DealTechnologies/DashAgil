using DashAgil.Integrador.Entidades.Devops;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Queries
{
    public interface IAzureDevopsQueries
    {
        Task<DevopsResult<ProjectsResult>> ObterProjetos(string organizacao);
        Task<DevopsResult<WorkItensTypeResult>> ObterWorkItensTypes(string organizacao, string time, string projeto);
        Task<DevopsResult<QueryResult>> ConsultarPorQuery(string organizacao);
    }
}
