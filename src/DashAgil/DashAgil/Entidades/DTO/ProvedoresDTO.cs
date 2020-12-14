using System.Collections.Generic;

namespace DashAgil.Entidades.DTO
{
    public class ProvedoresDTO
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public List<ClientesDTO> Clientes { get; set; }
    }
}
