using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class ProjetoRepositorio
    {
        private readonly DataContext _context;
        DynamicParameters _param = new DynamicParameters();
        public ProjetoRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<long> Inserir(Projeto projeto)
        {
            _param.Add("@ExternalId", projeto.ExternalId);
            _param.Add("@OrganizacaoId", projeto.OrganizacaoId);
            _param.Add("@Nome", projeto.Nome);
            _param.Add("@Descricao", projeto.Descricao);
            _param.Add("@DataCriacao", projeto.DataCriacao);
            _param.Add("@DataModificacao", projeto.DataModificacao);
            _param.Add("@DataExclusao", projeto.DataExclusao);

            var result = await _context.Connection.ExecuteScalarAsync<long>(
                @" INSERT INTO DashAgil.dbo.Projetos
                   (ExternalId, OrganizacaoId, Nome, Descricao, DataCriacao, DataModificacao, DataExclusao)
                   VALUES(@ExternalId, @OrganizacaoId, @Nome, @Descricao, @DataCriacao, @DataModificacao, @DataExclusa) ", _param
                );

            return result;
        }
    }
}



