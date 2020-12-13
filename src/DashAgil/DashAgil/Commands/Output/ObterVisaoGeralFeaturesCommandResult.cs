using DashAgil.Entidades.DashAgil;
using System.Collections.Generic;

namespace DashAgil.Commands.Output
{
    public class ObterVisaoGeralFeaturesCommandResult
    {
        public List<FeaturesEstagioResult> ListaFeaturesEstagio;
        public double PercentualFeaturesHomologacao { get; set; }
        public SprintBurndownResult SprintBurndown { get; set; }
    }
}
