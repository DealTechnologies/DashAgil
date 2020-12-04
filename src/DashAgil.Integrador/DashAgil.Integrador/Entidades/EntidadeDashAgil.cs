using System;

namespace DashAgil.Integrador.Entidades
{
    public abstract class EntidadeDashAgil
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime? DataCadastro { get; private set; } = DateTime.Now;
    }
}
