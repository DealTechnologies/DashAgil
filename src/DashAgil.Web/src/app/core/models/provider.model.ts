import { Client } from "./client.model";

export class Provider {
  id: number;
  descricao: string;
  ativo: boolean;
  clientes: Client[];
}
