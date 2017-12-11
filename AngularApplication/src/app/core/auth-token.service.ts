import { Injectable, OnDestroy } from '@angular/core';
import { environment } from '../../environments/environment';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthTokenService implements OnDestroy {

  tokenName = 'lpp-token';
  tokenStream: BehaviorSubject<string|null>;

  public authenticationUrl = environment.apiAuthUrl + '/connect/authorize' +
    '?client_id=' + environment.applicationId +
    '&response_type=code' +
    '&redirect_uri=' + environment.redirectUrl;

  constructor(
    private http: HttpClient
  ) {

    this.tokenStream = new BehaviorSubject( this.getToken() );
    this.tokenStream.subscribe(
      token => { this.setToken(token); }
    );
  }

  fetchToken(code: string) {
    return this.http.post('/api/users', { code }).pipe(
      tap(
        next => { this.getWalletToken(next).subscribe(); }
      )
    );
  }

  getWalletToken(data) {
    const headers = {
      'application_id': environment.applicationId,
      'Authorization': data.token_type + ' ' + data.access_token
    };

    return this.http.get(environment.apiAuthUrl + '/getlykkewallettoken', { headers }).pipe(
      tap(
        next => {
          if (next['token']) {
            this.tokenStream.next(next['token']);
          }
        }
      )
    );
  }

  private setToken(token) {
    if (token) {
      localStorage.setItem(this.tokenName, token);
    } else {
      localStorage.removeItem(this.tokenName);
    }
  }

  private getToken() {
    return localStorage.getItem(this.tokenName);
  }

  isAuthenticated() {
    return !!localStorage.getItem(this.tokenName);
  }

  ngOnDestroy() {
    this.tokenStream.unsubscribe();
  }

}
