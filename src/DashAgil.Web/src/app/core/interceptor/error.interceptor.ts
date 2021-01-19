import { AuthService } from '../services/auth/auth.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NotifierService } from 'angular-notifier';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthService, private notifier: NotifierService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err) => {
        if (err.status === 401) {
          this.authenticationService.logout();
          return throwError(err);
        }

        const errorMessage = this.getErrorMessage(err);

        this.notifier.notify('error', 'Ops, algo deu errado');
        // this.notifier.notify('error', `${errorMessage}`);

        return throwError(errorMessage);
      })
    );
  }

  private getErrorMessage(error: any) {
    if (error instanceof HttpErrorResponse) {
      return error.message || error.statusText;
    }

    if (typeof (error.error) == 'string') {
      return error.error;
    }

    return error.error.message || error.error.title;
  }
}
