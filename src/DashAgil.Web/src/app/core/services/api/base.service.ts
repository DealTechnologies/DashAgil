import { HttpClient, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { InRequest } from '../../interfaces';

export class BaseService<T> {

    protected url: string;

    constructor(protected http: HttpClient, controller: string) {
        this.url = `${environment.apiUrl}/${controller}`;
    }

    get(): Observable<T> {
        return this.http.get<T>(this.url).pipe(map((response: any) => {
            return response.data;
        }));
    }
}
