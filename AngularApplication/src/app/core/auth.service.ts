import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRequestService } from './auth-request.service';
import { AuthTokenService } from './auth-token.service';
import { NotificationsService } from '../notifications/notifications.service';

@Injectable()
export class AuthService {


  constructor(private router: Router,
              private authRequest: AuthRequestService,
              private authToken: AuthTokenService,
              private notifications: NotificationsService) {

  }

  login() {
    const url = this.router.routerState.snapshot.url;
    localStorage.setItem('lpp-return-url', url);
    window.location.replace(this.authToken.authenticationUrl);
  }

  logout(showMessage: boolean) {
    this.authRequest.post('/Auth/LogOut').subscribe(
      res => {
        if (showMessage) {
          const message = {event: 'sign-out'};
          this.notifications.messageStream.next(message);
          this.router.navigateByUrl('');
        }
        this.authToken.tokenStream.next(null);
      }
    );
  }


}
