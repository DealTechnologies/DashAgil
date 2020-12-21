export class OverviewDemand {

  listaEstoriasPorEstagio: {
    Remanescente: number;
    EmAndamento: number;
    DesenvolvimentoConcluido: number;
    Homologacao: number;
    Homologado: number;
    Concluido: number;
  };

  listaEstoriasPorSquad: { squadId: number, squadNome: string, quantidade: number }[];
  listaEvolucaoSquad: { squadNome: string, evolucaoAnterior: number, evolucaoAtual: number, evolucao: number }[];
  totalGeralEstorias: number;

  constructor() {
    this.listaEstoriasPorSquad = [];
    this.listaEvolucaoSquad = [];
    this.listaEstoriasPorEstagio = {
      Remanescente: 0,
      EmAndamento: 0,
      DesenvolvimentoConcluido: 0,
      Homologacao: 0,
      Homologado: 0,
      Concluido: 0,
    };

    this.totalGeralEstorias = 0;
  }
}

