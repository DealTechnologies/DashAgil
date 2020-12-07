using DashAgil.Integrador.Jira.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Entidades
{
    public class Projeto
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public long OrganizacaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public static Projeto PreencherInsercao(BoardQueryResult board, long organizacaoId)
        {
            return new Projeto()
            {
                ExternalId = Guid.NewGuid().ToString(),
                OrganizacaoId = organizacaoId,
                Nome = board.Project.ProjectName,
                Descricao = board.Project.DisplayName,
                DataCriacao = DateTime.Now
            };

        }

    }
}
