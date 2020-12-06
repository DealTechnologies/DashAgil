using DashAgil.Integrador.Infra.HTTP;
using DashAgil.Integrador.Jira.Entidades;
using DashAgil.Integrador.Jira.Queries;
using DashAgil.Integrador.Jira.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class BacklogRepositorio : IBacklogRepositorio
    {
        private readonly HttpService _httpService;
        private DadosAcesso _dadosAcesso;
        public BacklogRepositorio(HttpService httpService)
        {
            _httpService = httpService;
        }
        public void PreencherAcesso(string token, string url)
        {
            _dadosAcesso = new DadosAcesso(token, url);
        }

        public async Task<BacklogPaginateQueryResult> Obter(long boradId)
        {
            return await _httpService.GetAsync<BacklogPaginateQueryResult>(_dadosAcesso.BaseUrl, "board/"+boradId+"/backlog", _dadosAcesso.Token);
        }
    }
}
