using DashAgil.Integrador.Infra.HTTP;
using DashAgil.Integrador.Jira.Entidades;
using DashAgil.Integrador.Jira.Queries;
using DashAgil.Integrador.Jira.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class BoardRepositorio : IBoardRepositorio
    {
        private readonly HttpService _httpService;
        private DadosAcesso _dadosAcesso;
        public BoardRepositorio(HttpService httpService)
        {
            _httpService = httpService;
        }

        public void PreencherAcesso(string token, string url)
        {
            _dadosAcesso = new DadosAcesso(token, url);
        }

        public async Task<BoardPaginateQueryResult> Obter()
        {
            return await _httpService.GetAsync<BoardPaginateQueryResult>(_dadosAcesso.BaseUrl, "board", _dadosAcesso.Token);
        }
    }
}
