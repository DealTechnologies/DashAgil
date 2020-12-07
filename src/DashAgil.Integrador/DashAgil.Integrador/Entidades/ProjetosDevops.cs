using System;

namespace DashAgil.Integrador.Entidades
{
    public class ProjetosDevops : EntidadeDashAgil
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ProjetoId { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } 
    }
}
