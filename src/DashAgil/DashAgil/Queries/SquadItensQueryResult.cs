using DashAgil.Entidades;
using DashAgil.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashAgil.Queries
{
    public class SquadItensQueryResult
    {
        public string SquadNome { get; set; }
        public int Backlog { get; set; }
        public int Desenvolvimento { get; set; }
        public int DesenvolvimentoConcluido { get; set; }
        public int EmHomologacao { get; set; }
        public int Homologado { get; set; }
        public int Concluido { get; set; }
        public int Total { get; set; }

        public static SquadItensQueryResult ObterTotais(List<Demandas> demandas, string squad)
        {
            var demanda = new SquadItensQueryResult();

            demanda.Backlog = demandas.Count(x => x.StatusDeXPara.Equals(EDemandaStatusDexPara.Remanescente));

            demanda.Desenvolvimento = demandas.Count(x => x.StatusDeXPara.Equals(EDemandaStatusDexPara.EmAndamento));

            demanda.DesenvolvimentoConcluido = demandas.Count(x => x.StatusDeXPara.Equals(EDemandaStatusDexPara.DesenvolvimentoConcluido));

            demanda.EmHomologacao = demandas.Count(x => x.StatusDeXPara.Equals(EDemandaStatusDexPara.Homologacao));

            demanda.Homologado = demandas.Count(x => x.StatusDeXPara.Equals(EDemandaStatusDexPara.Homologado));

            demanda.Concluido = demandas.Count(x => x.StatusDeXPara.Equals(EDemandaStatusDexPara.Concluido));

            demanda.Total = demandas.Count();

            demanda.SquadNome = squad;

            return demanda;

        }



    }
}
