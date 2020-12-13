using Dapper;
using DashAgil.Integrador.Entidades;
using DashAgil.Integrador.Infra.Data.Context;
using DashAgil.Integrador.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Infra.Data.Repositorio
{
    public class SquadRepositorio : ISquadRepositorio
    {
        private readonly DataContext _context;
        DynamicParameters _param = new DynamicParameters();
        public SquadRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<long> Inserir(Squad squad)
        {

            _param.Add("@Nome", squad.Nome);
            _param.Add("@Descricao", squad.Descricao);
            _param.Add("@ProjetoId", squad.ProjetoId);
            _param.Add("@DataInicio", squad.DataInicio);
            _param.Add("@Status", squad.Status);

            var result = await _context.Connection.ExecuteScalarAsync<long>(
                @" INSERT INTO DashAgil.dbo.Squads
                    (Nome, Descricao, ProjetoId, DataInicio, Status)
                    VALUES(@Nome, @Descricao, @ProjetoId, @DataInicio, @Status);

                   SELECT SCOPE_IDENTITY() ", _param);

            return result;

        }
    }
}
