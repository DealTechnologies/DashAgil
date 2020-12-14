using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Infra.HTTP;
using DashAgil.Integrador.Jira.Entidades;
using DashAgil.Integrador.Jira.Queries.Sprints;
using DashAgil.Integrador.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class SprintRepositorio : ISprintRepositorio
    {
        private readonly HttpService _httpService;
        private DadosAcesso _dadosAcesso;
        private readonly DataContext _context;
        DynamicParameters _param = new DynamicParameters();
        public SprintRepositorio(HttpService httpService, DataContext context)
        {
            _httpService = httpService;
            _context = context;
        }

        public void PreencherAcesso(string token, string url)
        {
            _dadosAcesso = new DadosAcesso(token, url);
        }

        public async Task<SprintPaginateQueryResult> ObterSprintsJira(int boardId)
        {
            return await _httpService.GetAsync<SprintPaginateQueryResult>(_dadosAcesso.BaseUrl, "board/" + boardId + "/sprint", _dadosAcesso.Token);
        }

        public async Task<long> Inserir(Sprint sprint)
        {
            _param.Add("@ExternalId", sprint.ExternalId);
            _param.Add("@ProjetoId", sprint.ProjetoId);
            _param.Add("@Nome", sprint.Nome);
            _param.Add("@Descricao", sprint.Descricao);
            _param.Add("@DataInicio", sprint.DataInicio);
            _param.Add("@DataFim", sprint.DataFim);
            _param.Add("@DataConclusao", sprint.DataConclusao);
            _param.Add("@Status", (int)sprint.Status);

            var result = await _context.Connection.ExecuteScalarAsync<long>(
                   @" 
                    INSERT INTO DashAgil.dbo.Sprints
                    (ExternalId, ProjetoId, Nome, Descricao, DataInicio, DataFim, DataConclusao, Status)
                    VALUES(@ExternalId, @ProjetoId, @Nome, @Descricao, @DataInicio, @DataFim, @DataConclusao, @Status);
                    SELECT SCOPE_IDENTITY() ", _param);

            return result;
        }

        public async Task<List<Sprint>> Obter(long projetoId)
        {
            _param.Add("@ProjetoId", projetoId);

            var result = await _context.Connection.QueryAsync<Sprint>(
                   @" 
                    SELECT Id, ExternalId, ProjetoId, Nome, Descricao, DataInicio, DataFim, DataConclusao, Status
                    FROM DashAgil.dbo.Sprints WHERE ProjetoId = @ProjetoId
                    ", _param);

            return result.ToList();
        }

        public Task<Sprint> Obter(string nome)
            => _context.Connection.QueryFirstOrDefaultAsync<Sprint>("SELECT * FROM DashAgil.dbo.Sprints WHERE Nome  LIKE '%' + @nome + '%'  ", new { nome });
    }
}
