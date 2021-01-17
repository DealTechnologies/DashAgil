using System.Collections.Generic;

namespace LambdaAlexa.Models
{
    public class ListaEstoriasPorEstagio
    {
        public int Remanescente { get; set; }
        public int Homologacao { get; set; }
        public int Concluido { get; set; }
        public int DesenvolvimentoConcluido { get; set; }
        public int EmAndamento { get; set; }
        public int Homologado { get; set; }
    }

    public class ListaEstoriasPorSquad
    {
        public int quantidade { get; set; }
        public string squadNome { get; set; }
    }

    public class ListaEvolucaoSquad
    {
        public string squadNome { get; set; }
        public int evolucaoAnterior { get; set; }
        public int evolucaoAtual { get; set; }
        public int evolucao { get; set; }
    }

    public class Data
    {
        public ListaEstoriasPorEstagio listaEstoriasPorEstagio { get; set; }
        public List<ListaEstoriasPorSquad> listaEstoriasPorSquad { get; set; }
        public List<ListaEvolucaoSquad> listaEvolucaoSquad { get; set; }
        public int totalGeralEstorias { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}
