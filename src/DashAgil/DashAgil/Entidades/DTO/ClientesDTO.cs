using System.Collections.Generic;

namespace DashAgil.Entidades.DTO
{
    public class ClientesDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<SquadsDTO> Squads { get; set; }
    }
}
