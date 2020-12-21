using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Queries
{
    public class DemandaSprintQueryResult
    {

    }
}


//d.Id, d.SquadId, d.Tipo, d.Status, d.Descricao, isnull(d.Pontos, 0) as Pontos,
//                                 s.Nome as SprintNome, s.DataInicio as SprintDataInicio, s.DataFim as SprintDataFim,
//                                 dh.Id as IdHistorico, dh.DataModificacao, isnull(v.status_novo_num, 1) as StatusDeXPara