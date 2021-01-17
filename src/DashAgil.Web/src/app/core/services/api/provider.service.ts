import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Provider } from '../../models';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class ProviderService extends BaseService<Provider> {
  constructor(http: HttpClient) {
    super(http, 'Provedor');
  }

  getProviders(): Observable<Provider[]> {
    return this.http
      .get<Provider>(`${this.url}/ObterProvedores`).pipe(map((req: any) => {
        return req.data;
      }));
  }
}
