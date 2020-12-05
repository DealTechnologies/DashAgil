using DashAgil.Integrador.Jira.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Jira.Repositorio
{
    public interface IBacklogRepositorio
    {
        void PreencherAcesso(string token, string url);
        Task<BacklogPaginateQueryResult> Obter(long boardId);
    }
}
