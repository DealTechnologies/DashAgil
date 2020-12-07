import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

export class BaseService<T> {

    url: string;

    constructor(protected http: HttpClient, controller: string) {
        this.url = `${environment.apiUrl}/${controller}`;
    }

    get(): Observable<T> {
        return this.http.get<T>(this.url);
    }
}
