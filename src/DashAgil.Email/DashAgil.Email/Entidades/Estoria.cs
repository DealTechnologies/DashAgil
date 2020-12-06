namespace DashAgil.Entidades
{
    public class Estoria
    {
        public Estoria(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
