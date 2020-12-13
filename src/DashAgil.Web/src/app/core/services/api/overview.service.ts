import { Injectable } from '@angular/core';
import { HttpClient,  HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { Overview } from '../../models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class OverviewService extends BaseService<Overview> {
    constructor(http: HttpClient) {
        super(http, 'VisaoGeral');
    }

    getDemandsOverview(projectId: number)  {
        return this.http
        .get<Overview>(`${this.url}/ObterVisaoGeralDemandas`, { params: { IdProjeto: projectId.toString() }})
        .pipe(map((req: any) => {
            return req.data;
        }));;
    }

}
