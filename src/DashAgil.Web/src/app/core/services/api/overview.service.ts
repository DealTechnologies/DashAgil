import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Overview } from '../../models';
import { Observable } from 'rxjs';

@Injectable()
export class OverviewService extends BaseService<Overview> {
    constructor(http: HttpClient) {
        super(http, 'VisaoGeral');
    }

    getDemandsOverview(): Observable<Overview> {
        return this.http.get<Overview>(`${this.url}/ObterVisaoGeralDemandas/`);
    }

    
}
