using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class ProjetoIntegracaoRepositorio : IProjetoIntegracaoRepositorio
    {
        private readonly DataContext _context;
        DynamicParameters _param = new DynamicParameters();
        public ProjetoIntegracaoRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task Inserir(ProjetoIntegracao projetoIntegracao)
        {
            _param.Add("@ProjetoId", projetoIntegracao.ProjetoId);
            _param.Add("@ProjetoOrigemId", projetoIntegracao.ProjetoOrigemId);
            _param.Add("@ProvedorId", projetoIntegracao.ProvedorId);
            _param.Add("@UrlOrigem", projetoIntegracao.UrlOrigem);

            await _context.Connection.ExecuteAsync(
               @"INSERT INTO DashAgil.dbo.ProjetoIntegracao
                (ProjetoId, ProjetoOrigemId, ProvedorId, UrlOrigem)
                VALUES(@ProjetoId, @ProjetoOrigemId, @ProvedorId, @UrlOrigem) ", _param
                );
        }


        public async Task<List<ProjetoIntegracao>> ObterPorUrl(string url)
        {
            _param.Add("@Url", url);

            var result = await _context.Connection.QueryAsync<ProjetoIntegracao>(
              @"select * from DashAgil.dbo.ProjetoIntegracao where UrlOrigem like '%'+@Url+'%'  ", _param);

            return result.ToList();

        }
    }
}



