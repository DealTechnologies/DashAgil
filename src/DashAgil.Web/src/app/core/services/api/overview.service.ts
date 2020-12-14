import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { OverviewDemand, OverviewFeature } from '../../models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class OverviewService extends BaseService<OverviewDemand> {
  constructor(http: HttpClient) {
    super(http, 'VisaoGeral');
  }

  getOverviewDemands(clientId: number): Observable<OverviewDemand> {
    return this.http
      .get<OverviewDemand>(`${this.url}/ObterVisaoGeralDemandas`, { params: { IdCliente: clientId.toString() } })
      .pipe(map((req: any) => {
        return req.data;
      }));;
  }

  getOverviewFeatures(projectId: number, squadId: number, sprintId: number): Observable<OverviewFeature> {
    const params = { IdProjeto: projectId.toString(), IdSquad: squadId.toString(), IdSprint: sprintId.toString() };

    return this.http
      .get<OverviewDemand>(`${this.url}/ObterVisaoGeralFeatures`, { params: params })
      .pipe(map((req: any) => {
        return req.data;
      }));;
  }

}
