import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { Demand, OverviewDemand, OverviewFeature } from '../../models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class OverviewService extends BaseService<OverviewDemand> {
  constructor(http: HttpClient) {
    super(http, 'VisaoGeral');
  }

  getOverviewDemands(clientId: number, userId: number): Observable<OverviewDemand> {
    const params = { IdCliente: clientId.toString(), IdUsuario: userId.toString() };

    return this.http
      .get<OverviewDemand>(`${this.url}/ObterVisaoGeralDemandas`, { params: params })
      .pipe(map((req: any) => {
        return req.data;
      }));;
  }

  getOverviewFeatures(clientId: number, squadId: number, sprintId: number): Observable<OverviewFeature> {
    const params = { IdCliente: clientId.toString(), IdSquad: squadId.toString(), IdSprint: sprintId.toString() };

    return this.http
      .get<OverviewDemand>(`${this.url}/ObterVisaoGeralFeatures`, { params: params })
      .pipe(map((req: any) => {
        return req.data;
      }));;
  }

  getDemandList(clientId: number, squadId: number, userId?: number): Observable<Demand[]> {
    const params = { IdCliente: clientId.toString(), IdSquad: squadId.toString() };

    return this.http
      .get<Demand>(`${this.url}/ObterListaEstoriasSquad`, { params: params })
      .pipe(map((req: any) => {
        return req.data.listaDemandas;
      }));;
  }

}
