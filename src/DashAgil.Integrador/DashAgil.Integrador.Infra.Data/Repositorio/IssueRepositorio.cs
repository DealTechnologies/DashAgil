using DashAgil.Integrador.Infra.HTTP;
using DashAgil.Integrador.Jira.Entidades;
using DashAgil.Integrador.Jira.Queries;
using DashAgil.Integrador.Jira.Queries.Issues;
using DashAgil.Integrador.Jira.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class IssueRepositorio : IIssuegRepositorio
    {
        private readonly HttpService _httpService;
        private DadosAcesso _dadosAcesso;
        public IssueRepositorio(HttpService httpService)
        {
            _httpService = httpService;
        }
        public void PreencherAcesso(string token, string url)
        {
            _dadosAcesso = new DadosAcesso(token, url);
        }

        public async Task<IssuesPaginateQueryResult> Obter(long boradId)
        {
            return await _httpService.GetAsync<IssuesPaginateQueryResult>(_dadosAcesso.BaseUrl, "board/"+boradId+"/issue", _dadosAcesso.Token);
        }
    }
}
