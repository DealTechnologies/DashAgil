import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../../models/user.model';
import { BaseService } from '../api/base.service';
import { Router } from '@angular/router';
import { orderBy } from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService<User>  {

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(http: HttpClient, private router: Router) {
    super(http, 'Authenticate');

    try {
      this.currentUserSubject = new BehaviorSubject<User>(
        JSON.parse(localStorage.getItem('currentUser'))
      );

      this.currentUser = this.currentUserSubject.asObservable();
    } catch (error) {
      console.error(error);
      this.logout();
    }
  }

  get userId(): string {
    return this.currentUserSubject.value.id;
  }

  get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  get clients() {
    return this.currentUserValue.provedores.map(item => item.clientes).reduce((x, y) => x.concat(y), []);
  }

  login(username: string, password: string) {
    return this.http
      .post<any>(`${this.url}`, { username, password })
      .pipe(map((resp) => {
        if (resp.data == null || !resp.data.length)
          throw 'InvalidUser';

        const user = this.orderSquads(resp.data[0]);

        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  orderSquads(user: User) {
    user.provedores.forEach(prov => {
      prov.clientes = orderBy(prov.clientes, 'nome', 'asc');
      prov.clientes.forEach(cli => {
        cli.squads = orderBy(cli.squads, 'nome', 'asc');
      });
    });

    return user;
  }

  logout() {
    localStorage.removeItem('currentUser');

    if (this.currentUserSubject)
      this.currentUserSubject.next(null);

    return of({ success: false });
  }
}
