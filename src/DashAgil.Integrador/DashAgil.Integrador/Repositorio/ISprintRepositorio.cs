using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Jira.Queries.Sprints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Repositorio
{
    public interface ISprintRepositorio
    {
        void PreencherAcesso(string token, string url);

        Task<SprintPaginateQueryResult> ObterSprintsJira(int boardId);

        Task<long> Inserir(Sprint sprint);

        Task<List<Sprint>> Obter(long projetoId);
    }
}
