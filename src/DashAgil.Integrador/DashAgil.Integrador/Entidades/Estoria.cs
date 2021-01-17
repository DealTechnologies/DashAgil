namespace DashAgil.Integrador.Entidades
{
    public class Estoria
    {
        public Estoria(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
