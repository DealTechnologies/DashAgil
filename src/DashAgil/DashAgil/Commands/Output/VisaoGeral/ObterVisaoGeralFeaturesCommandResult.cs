using DashAgil.Entidades.DashAgil;
using System.Collections.Generic;

namespace DashAgil.Commands.Output.VisaoGeral
{
    public class ObterVisaoGeralFeaturesCommandResult
    {
        public List<FeaturesEstagioResult> ListaFeaturesEstagio { get; set; }
        public double PercentualFeaturesHomologacao { get; set; }
        public SprintBurndownResult SprintBurndown { get; set; }
    }
}
