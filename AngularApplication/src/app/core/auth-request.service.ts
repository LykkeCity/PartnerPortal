import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AuthTokenService } from './auth-token.service';
import { catchError } from 'rxjs/operators';
import { _throw } from 'rxjs/observable/throw';
import { Router } from '@angular/router';

@Injectable()
export class AuthRequestService {

  token: string;

  constructor(
    private http: HttpClient,
    private authToken: AuthTokenService,
    private router: Router
  ) {

    this.authToken.tokenStream.subscribe(
      token => {
        this.token = token;
      }
    );

  }

  public get(url: string, options?: object) {
    const reqUrl = environment.apiUrl + url;
    const headers = {
      'Authorization': 'Bearer ' + this.token
    };
    const reqOptions = Object.assign({}, options, {headers});

    return this.http.get(reqUrl, reqOptions).pipe(
      catchError( error => this.handleError(error) )
    );
  }

  public post(url: string, body: object = {}, options?: object) {
    const reqUrl = environment.apiUrl + url;
    const headers = {
      'Authorization': 'Bearer ' + this.token
    };
    const reqOptions = Object.assign({}, options, {headers});

    return this.http.post(reqUrl, body, reqOptions).pipe(
      catchError( error => this.handleError(error) )
    );
  }

  private handleError(error) {
    console.log('api error occured');
    if (error.status === 401) {
      this.router.navigateByUrl('').then(
        success => {
          console.log('401 occurred');
        }
      );
    }
    return _throw(error);
  }

}
