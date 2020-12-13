export class Overview {
  demandasPorEstagio: { statusDeXPara: string, quantidade: number }[];
  demandasPorSquad: { nomeSquad: string, quantidade: number }[];
  evolucaoSquad: { nomeSquad: string, evolucaoAnterior: number, evolucaoAtual: number }[];
  totalDemandas: number;
}
