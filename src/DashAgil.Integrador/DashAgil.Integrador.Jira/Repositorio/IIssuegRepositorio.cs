using DashAgil.Integrador.Jira.Queries;
using DashAgil.Integrador.Jira.Queries.Issues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Jira.Repositorio
{
    public interface IIssuegRepositorio
    {
        void PreencherAcesso(string token, string url);
        Task<IssuesPaginateQueryResult> Obter(long boardId);
    }
}
