using DashAgil.Integrador.Entidades;

namespace DashAgil.Integrador.DevOps.Commands.Output
{
    class TratamentoHistoricoResult
    {
        public TratamentoHistoricoResult(Demandas demandaPai, int? storyPoint)
        {
            DemandaPai = demandaPai;
            StoryPoint = storyPoint;
        }

        public Demandas DemandaPai { get; set; }
        public int? StoryPoint { get; set; }
    }
}
