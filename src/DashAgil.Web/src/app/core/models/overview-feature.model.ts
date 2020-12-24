export class OverviewFeature {
  ListaPercentual: {
    PercentualFeaturesHomologacao: number,
    PercentualFeaturesConclusao: number
  };

  sprintBurndown: {
    id: number,
    nome: string,
    dataInicio: Date,
    dataFim: Date,
    demandasHistoricos: {
      dia: Date,
      pontosTotalDia: number,
      pontosConcluidosDia: number
    }[];
  };

  ListaFeaturesEstagio: {
    featureId: string,
    featureDescricao: string,
    remanescente: number,
    emAndamento: number,
    desenvolvimentoConcluido: number,
    homologacao: number,
    homologado: number,
    concluido: number,
  }[];
}
