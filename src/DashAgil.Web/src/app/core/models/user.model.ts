import { Provider } from "./provider.model";

export class User {
  id: number;
  nome: string;
  provedores: Provider[];
  token: string;
}
