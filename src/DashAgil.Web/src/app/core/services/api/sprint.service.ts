import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { Sprint } from '../../models';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class SprintService extends BaseService<Sprint> {
  constructor(http: HttpClient) {
    super(http, 'Sprint');
  }

  getSprintsBySquad(squadId: number): Observable<Sprint[]> {
    return this.http
      .get(`${this.url}/Squad/${squadId}`).pipe(map((response: any) => {
        return response;
      }));
  }
}
