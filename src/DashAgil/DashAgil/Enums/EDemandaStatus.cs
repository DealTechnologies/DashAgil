using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Enums
{
    public enum EDemandaStatus
    {
        Backlog = 1,
        Priorizado = 2,
        AnaliseViabilidade = 3,
        Especificacao = 4,
        BacklogDesenvolvimento = 5,
        Desenvolvimento = 6,
        GC = 7,
        PacoteLiberado = 8,
        Homologacao = 9,
        FilaProducao = 10,
        Concluido = 11,
        PromoverMain = 12        
    }
}
