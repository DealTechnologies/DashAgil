import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Email } from '../../models';
import { BaseService } from './base.service';

@Injectable()
export class EmailService extends BaseService<Email> {
    constructor(http: HttpClient) {
        super(http, 'DashAgil');
    }

    getAll(): Observable<Email[]> {
        return this.http.get<Email[]>(`${this.urlEmail}`);
    }

    getCount() {
        return this.http.get(`${this.urlEmail}/Count`);
    }
}
