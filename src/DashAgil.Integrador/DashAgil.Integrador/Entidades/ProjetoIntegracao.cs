using DashAgil.Integrador.Jira.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Entidades
{
    public class ProjetoIntegracao
    {
        public ProjetoIntegracao()
        {

        }

        public int Id { get; set; }

        public long ProjetoId { get; set; }

        public string ProjetoOrigemId { get; set; } // JIRA OU DEVOPS

        public long? ProvedorId { get; set; }

        public string UrlOrigem { get; set; }

        public static ProjetoIntegracao PreencherInsercao(BoardQueryResult board, long projetoId, long? provedorId)
        {
            return new ProjetoIntegracao()
            {
                ProjetoId = projetoId,
                ProjetoOrigemId = board.Id.ToString(),
                ProvedorId = provedorId,
                UrlOrigem = board.Url
            };
        }
    }
}
