import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { CommandResult, Provider } from '../../models';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class ProviderService extends BaseService<Provider> {
  constructor(http: HttpClient) {
    super(http, 'Provedor');
  }

  getProviders(): Observable<Provider[]> {
    return this.http
      .get(`${this.url}/ObterProvedores`).pipe(map((response: CommandResult) => {
        return response.data;
      }));
  }
}
