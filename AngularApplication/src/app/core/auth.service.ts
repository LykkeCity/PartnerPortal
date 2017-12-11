import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRequestService } from './auth-request.service';
import { AuthTokenService } from './auth-token.service';

@Injectable()
export class AuthService {


  constructor(
    private router: Router,
    private authRequest: AuthRequestService,
    private authToken: AuthTokenService
  ) {

  }

  login() {
    const url = this.router.routerState.snapshot.url;
    localStorage.setItem('lpp-return-url', url);
    window.location.replace(this.authToken.authenticationUrl);
  }

  logout() {
    this.authRequest.post('/Auth/LogOut').subscribe();
    this.authToken.tokenStream.next(null);
  }



}
