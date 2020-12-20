using Dapper;
using DashAgil.Entidades;
using DashAgil.Infra.Data.Context;
using DashAgil.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashAgil.Infra.Data.Repositorio
{
    public class RadarAgilRepository : IRadarAgilRepository
    {
        private readonly DataContext _context;
        DynamicParameters _param = new DynamicParameters();
        public RadarAgilRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Inserir(RadarAgil radar)
        {
            _param.Add("@SquadId", radar.SquadId);
            _param.Add("@ProjetoId", radar.ProjetoId);
            _param.Add("@DataExecucao", radar.DataExecucao);
            _param.Add("@SprintId", radar.SprintId);
            _param.Add("@NomeSquad", radar.NomeSquad);
            _param.Add("@JsonRadar", radar.JsonRadar);

            var result = await _context.Connection.ExecuteAsync(
                             @" INSERT INTO DashAgil.dbo.RadarAgil
                            (SquadId, ProjetoId, DataExecucao, SprintId, NomeSquad, JsonRadar)
                            VALUES(@SquadId, @ProjetoId, @DataExecucao, @SprintId, @NomeSquad, @JsonRadar);
                            SELECT SCOPE_IDENTITY() ", _param);
        }

        public async Task<List<RadarAgil>> Obter(string squaidId)
        {
            _param.Add("@SquadId", squaidId);

            var result = await _context.Connection.QueryAsync<RadarAgil>(
              @" select * from DashAgil.dbo.RadarAgil where SquadId = @SquadId ", _param);

            return result.ToList();

        }
    }
}
