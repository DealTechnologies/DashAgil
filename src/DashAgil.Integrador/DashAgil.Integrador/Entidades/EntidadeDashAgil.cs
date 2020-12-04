using System;

namespace DashAgil.Integrador.Entidades
{
    public abstract class EntidadeDashAgil
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public DateTime? DataCadastro { get; private set; } = DateTime.Now;
    }
}
