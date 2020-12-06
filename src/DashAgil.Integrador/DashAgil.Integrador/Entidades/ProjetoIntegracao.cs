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

        public int ProjetoId { get; set; }

        public string ProjetoOrigemId { get; set; } // JIRA OU DEVOPS

        public int ProvedorId { get; set; }

        public string UrlOrigem { get; set; }

        public static ProjetoIntegracao PreencherInsercao(BoardQueryResult board)
        {
            return new ProjetoIntegracao()
            {
                ProjetoId = 1,
                ProjetoOrigemId = board.Id.ToString(),
                ProvedorId = 1,
                UrlOrigem = board.Url
            };
        }
    }
}
