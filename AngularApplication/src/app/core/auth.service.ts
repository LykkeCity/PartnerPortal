import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';

@Injectable()
export class AuthService {

  authenticationUrl: string;

  constructor(
    private http: HttpClient,
    private router: Router
  ) {

    this.authenticationUrl = environment.apiAuthUrl + '/connect/authorize' +
      '?client_id=' + environment.applicationId +
      '&response_type=code' +
      '&redirect_uri=' + environment.redirectUrl;

  }

  login() {
    const url = this.router.routerState.snapshot.url;
    localStorage.setItem('lpp-return-url', url);
    window.location.replace(this.authenticationUrl);
  }

  getToken(code: string) {
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
          next => { this.setToken(next['token']); }
        )
      );
  }

  private setToken(data) {
    localStorage.setItem('lpp-token', data);
  }

  isAuthenticated() {
    return !!localStorage.getItem('lpp-token');
  }


}
