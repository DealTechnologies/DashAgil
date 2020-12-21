import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CommandResult, Email, EmailCount } from '../../models';
import { BaseService } from './base.service';

@Injectable()
export class EmailService extends BaseService<Email> {
    constructor(http: HttpClient) {
        super(http, 'DashAgil');
    }

    getAll(): Observable<Email[]> {
        return this.http.get<Email[]>(`${this.urlEmail}`);
    }

    getCount(): Observable<EmailCount> {
        return this.http.get(`${this.urlEmail}/Count`).pipe(map((response: any) => {
          return response;
        }));
    }
}
