using DashAgil.Integrador.Jira.Queries;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Jira.Repositorio
{
    public interface IBoardRepositorio
    {
        Task<BoardPaginateQueryResult> Obter();
        void PreencherAcesso(string token, string url);
    }
}
