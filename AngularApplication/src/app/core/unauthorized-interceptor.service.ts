import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { tap } from 'rxjs/operators';
@Injectable()
export class UnauthorizedInterceptorService implements HttpInterceptor {

  constructor() {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        tap(
          res => {},
          err => {
            if (err.status === 401) {
              // TODO: perform proper actions when 401 error is received
              // this.authToken.tokenStream.next(null);
            }
          }
        )
      );
  }

}
