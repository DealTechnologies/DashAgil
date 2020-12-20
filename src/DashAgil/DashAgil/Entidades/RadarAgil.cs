using DashAgil.Commands.Input.RadarAgil;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Entidades
{
    public class RadarAgil
    {
        public long Id { get; set; }
        public long SquadId { get; set; }
        public DateTime DataExecucao { get; set; }
        public long? ProjetoId { get; set; }
        public long? SprintId { get; set; }
        public string NomeSquad { get; set; }
        public string JsonRadar { get; set; }

        public static RadarAgil PreencherRadar(InserirRadarCommand command)
        {
            return new RadarAgil()
            {
                SquadId = command.SquadId,
                DataExecucao = command.DataExecucao,
                ProjetoId = command.ProjetoId,
                SprintId = command.SprintId,
                NomeSquad = command.NomeSquad,
                JsonRadar = command.JsonRadar
            };
        }

    }
}
