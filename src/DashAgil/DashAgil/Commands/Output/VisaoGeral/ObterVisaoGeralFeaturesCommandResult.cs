using DashAgil.Entidades.DashAgil;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DashAgil.Commands.Output.VisaoGeral
{
    public class ObterVisaoGeralFeaturesCommandResult
    {
        public List<FeaturesEstagioResult> ListaFeaturesEstagio { get; set; }        
        public SprintBurndownResult SprintBurndown { get; set; }
    }
}
