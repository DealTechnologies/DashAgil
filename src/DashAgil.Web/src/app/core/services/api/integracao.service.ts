
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { map } from 'rxjs/operators';
import { CommandResult } from '../../models/command-result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IntegracaoService extends BaseService<CommandResult> {

  protected url: string;

  constructor(http: HttpClient) {
    super(http, 'CommandResult');
    this.url = environment.apiIntegracao;
  }

  syncInicialJira(clienteId: number, organizacaoId: number, token: string)
  {
    const command = {organizacaoId, token, clienteId }
    return this.http
    .post<CommandResult>(`${this.url}/IntegradorJira`, command)
    .pipe(map((req: CommandResult) =>  req ));
  }

  syncInicialDevops(clienteId: number, organizacao: string, token: string)
  {
    const command =  { Organizacao: organizacao, Token: token, ClienteId: clienteId }
    return this.http
      .post<CommandResult>(`${this.url}/v1/devops/sync`, command)
      .pipe(map((req: CommandResult) =>  req ));
  }
}
