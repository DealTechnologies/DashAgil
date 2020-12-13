using DashAgil.Entidades.DashAgil;
using System.Collections.Generic;

namespace DashAgil.Commands.Output.VisaoGeral
{
    public class ObterVisaoGeralDemandasCommandResult
    {
        public List<DemandaEstagioResult> ListaEstoriasPorEstagio { get; set; }
        public List<DemandaSquadResult> ListaEstoriasPorSquad { get; set; }
        public List<SquadEvolucaoResult> ListaEvolucaoSquad { get; set; }
        public long TotalGeralEstorias { get; set; }
    }
}
