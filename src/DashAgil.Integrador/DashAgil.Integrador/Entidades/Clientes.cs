using System;

namespace DashAgil.Integrador.Entidades
{
    public class Clientes
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long ProvedorId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public long Status { get; set; }
    }
}
