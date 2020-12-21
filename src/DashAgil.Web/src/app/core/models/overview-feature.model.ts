export class OverviewFeature {
  ListaPercentual: {
    PercentualFeaturesHomologacao: number,
    PercentualFeaturesConclusao: number
  };

  SprintBurndown: {
    id: number,
    nome: string,
    dataInicio: Date,
    dataFim: Date,
    demandasHistoricos: {
      dia: Date,
      velocidadeIdeal: number,
      velocidadeSprint: number
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
