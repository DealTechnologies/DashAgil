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

        public int ProjetoId { get; set; }

        public int ProjetotoIntegracaoId { get; set; }

        public int? ProjetoOrigemId { get; set; }

        public int ProvedorId { get; set; }

        public string UrlOrigem { get; set; }

        public static ProjetoIntegracao PreencherInsercao(BoardQueryResult board)
        {
            return new ProjetoIntegracao()
            {
                ProjetoId = 1,
                ProjetoOrigemId = board.Id,
                ProvedorId = 1,
                UrlOrigem = board.Url
            };
        }
    }
}
