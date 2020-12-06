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
    public class DemandaHistoricoRepositorio : IDemandaHistoricoRepositorio
    {
        private readonly DataContext _context;
        DynamicParameters _param = new DynamicParameters();
        public DemandaHistoricoRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task Inserir(DemandaHistorico demandaHistorico)
        {
            _param.Add("@Id", demandaHistorico.Id);
            _param.Add("@ExternalId", demandaHistorico.ExternalId);
            _param.Add("@SprintId", demandaHistorico.SprintId);
            _param.Add("@ProjetoId", demandaHistorico.ProjetoId);
            _param.Add("@SquadId", demandaHistorico.SquadId);
            _param.Add("@Tipo", demandaHistorico.Tipo);
            _param.Add("@DemandaPaiId", demandaHistorico.DemandaPaiId);
            _param.Add("@DataInicio", demandaHistorico.DataInicio);
            _param.Add("@DataModificacao", demandaHistorico.DataModificacao);
            _param.Add("@DataFim", demandaHistorico.DataFim);
            _param.Add("@Pontos", demandaHistorico.Pontos);
            _param.Add("@Tags", demandaHistorico.Tags);
            _param.Add("@Prioridade", demandaHistorico.Prioridade);
            _param.Add("@HorasEstimadas", demandaHistorico.HorasEstimadas);
            _param.Add("@HorasRestantes", demandaHistorico.HorasRestantes);
            _param.Add("@HorasUtilizadas", demandaHistorico.HorasUtilizadas);
            _param.Add("@HorasUtilizadas", demandaHistorico.HorasUtilizadas);
            _param.Add("@Risco", demandaHistorico.Risco);
            _param.Add("@Comentario", demandaHistorico.Comentario);
            _param.Add("@Statusx", demandaHistorico.Status);


            await _context.Connection.ExecuteAsync(
                @" 
                INSERT INTO DashAgil.dbo.DemandaHistorico
                (Id, ExternalId, SprintId, ProjetoId, SquadId, Tipo, DemandaPaiId, Responsavel, DataInicio, DataModificacao, DataFim, Pontos, Tags, Prioridade, HorasEstimadas, HorasRestantes, HorasUtilizadas, Risco, Comentario, Status)
                VALUES(@Id, @ExternalId, @SprintId, @ProjetoId, @SquadId, @Tipo, @DemandaPaiId, @Responsavel, @DataInicio, @DataModificacao, @DataFim, @Pontos, @Tags, @Prioridade, @HorasEstimadas, @HorasRestantes, @HorasUtilizadas, @Risco, @Comentario, @Status)
                ", _param);

        }
    }
}
