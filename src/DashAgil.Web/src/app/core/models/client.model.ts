import { Squad } from "./squad.model";

export class Client {
  id: number;
  nome: string;
  dataInicio: Date;
  dataCancelamento: Date;
  status: number;
  squads: Squad[];
}
