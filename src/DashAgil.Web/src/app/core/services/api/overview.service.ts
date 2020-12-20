import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { Demand, OverviewDemand, OverviewFeature, SquadStory } from '../../models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class OverviewService extends BaseService<OverviewDemand> {
  constructor(http: HttpClient) {
    super(http, 'VisaoGeral');
  }

  getOverviewDemands(clientId: number, userId: string): Observable<OverviewDemand> {
    const params = { IdCliente: clientId.toString(), IdUsuario: userId.toString() };

    return this.http
      .get<OverviewDemand>(`${this.url}/ObterVisaoGeralDemandas`, { params: params })
      .pipe(map((response: any) => {
        return response.data;
      }));;
  }

  getOverviewFeatures(clientId: number, squadId: number, sprintId: number): Observable<OverviewFeature> {
    const params = { IdCliente: clientId.toString(), IdSquad: squadId.toString(), IdSprint: sprintId.toString() };

    return this.http
      .get<OverviewDemand>(`${this.url}/ObterVisaoGeralFeatures`, { params: params })
      .pipe(map((response: any) => {
        return response.data;
      }));;
  }

  getDemandList(clientId: number, squadId: number, userId: string): Observable<Demand[]> {
    const params = { IdCliente: clientId.toString(), IdSquad: squadId.toString() };

    return this.http
      .get<Demand>(`${this.url}/ObterListaEstoriasSquad`, { params: params })
      .pipe(map((response: any) => {
        return response.data.listaDemandas;
      }));;
  }

  getSquadStories(clientId: number, userId: string): Observable<SquadStory[]> {
    const params = { IdCliente: clientId.toString(), IdUsuario: userId.toString() };

    return this.http
      .get<Demand>(`${this.url}/ObterVisaoEstoriasPorSquad`, { params: params })
      .pipe(map((response: any) => {
        return response.data;
      }));;
  }

}
