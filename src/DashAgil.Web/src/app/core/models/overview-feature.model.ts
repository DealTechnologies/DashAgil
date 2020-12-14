export class OverviewFeature {
  percentualFeaturesHomologacao: number;
  sprintBurndown: { id: number, nome: string, dataInicio: Date, dataFim: Date, demandasHistoricos: { dia: Date, pontosTotalDia: number, pontosConcluidosDia: number }[] };
  listaFeaturesEstagio: { featureId: string, featuredescricao: string, statusDeXPara: string, quantidade: number, percentual: number }[];
}
