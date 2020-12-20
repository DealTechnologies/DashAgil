import { Provider } from './provider.model';

export class User {
  id: string;
  nome: string;
  provedores: Provider[];
  token: string;
}
