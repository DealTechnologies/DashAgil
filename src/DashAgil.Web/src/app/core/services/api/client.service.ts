import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Client, CommandResult } from '../../models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ClientService extends BaseService<Client> {
  constructor(http: HttpClient) {
    super(http, 'Cliente');
  }

  getClientByProvider(providerId: number): Observable<Client[]> {
    return this.http
      .get(`${this.url}/ObterClientesPorCliente`, { params: { IdProvedor: providerId.toString() } })
      .pipe(map((response: CommandResult) => {
        return response.data;
      }));
  }

  sendEmail() {
    return this.http.post(`${this.url}`, null);
  }
}
