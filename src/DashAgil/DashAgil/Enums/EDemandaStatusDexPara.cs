using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DashAgil.Enums
{
    public enum EDemandaStatusDexPara
    {
        [Description("Remanescente")]
        Remanescente = 1,
        [Description("Em Desenvolvimento")]
        EmAndamento = 2,
        [Description("Desenvolvimento Concluído")]
        DesenvolvimentoConcluido = 3,
        [Description("Em Homologação")]
        Homologacao = 4,
        [Description("Homologado")]
        Homologado = 5,
        [Description("Concluído")]
        Concluido = 6
    }
}
