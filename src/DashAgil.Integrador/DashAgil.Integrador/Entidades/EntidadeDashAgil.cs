using System;

namespace DashAgil.Integrador.Entidades
{
    public abstract class EntidadeDashAgil
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
    }
}
