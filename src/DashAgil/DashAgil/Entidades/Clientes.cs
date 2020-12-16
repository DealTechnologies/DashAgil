using System;

namespace DashAgil.Entidades
{
    public class Clientes
    {
        public Clientes() { }        
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataCancelamento { get; set; }
        public int Status { get; set; }
    }
}
