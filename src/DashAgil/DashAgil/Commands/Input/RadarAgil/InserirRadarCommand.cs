using DashAgil.Infra.Comum;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Commands.Input.RadarAgil
{
    public class InserirRadarCommand : Notifiable, ICommandPadrao
    {
        public long SquadId { get; set; }
        public DateTime DataExecucao { get; set; }
        public long? ProjetoId { get; set; }
        public long? SprintId { get; set; }
        public string NomeSquad { get; set; }
        public string JsonRadar { get; set; }
        public bool EhValido()
        {
            return Valid;
        }
    }
}
