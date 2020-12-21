import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { InRequest } from '../../interfaces';
import { CommandResult } from '../../models';

export class BaseService<T> {

    protected url: string;

    public urlEmail: string;

    constructor(protected http: HttpClient, controller: string) {
        this.url = `${environment.apiUrl}/${controller}`;
        this.urlEmail = `${environment.apiEmail}/${controller}`;
    }

    get(): Observable<T> {
        return this.http.get(this.url).pipe(map((response: CommandResult) => {
            return response.data;
        }));
    }
}
