import { Injectable, OnDestroy } from '@angular/core';
import { Intercom } from 'ng-intercom';
import { AuthTokenService } from '../core/auth-token.service';
import { UserService } from '../core/user.service';
import { Subscription } from 'rxjs/Subscription';

@Injectable()
export class IntercomService implements OnDestroy {

  userServiceSubscription: Subscription;
  private token: string;

  constructor(
    private intercom: Intercom,
    private authToken: AuthTokenService,
    private userService: UserService
  ) { }

  initIntercom() {
    this.authToken.tokenStream.subscribe(
      res => {
        if (!res) {
          if (this.token) {
            // destroy logged-in user chat session
            this.intercom.shutdown();
          }
          this.intercom.boot();
        } else {
          this.token = res;
          this.userServiceSubscription = this.userService.getUserInfo().subscribe(
            user => {
              this.intercom.shutdown();
              this.intercom.boot({
                name: user['FullName'],
                email: user['Email']
              });
            }
          );
        }
      }
    );
  }

  showIntercomLauncher() {
    const intercomElement = document.getElementById('intercom-container');
    if (intercomElement) {
      intercomElement.classList.remove('d-none');
    }
  }

  hideIntercomLauncher() {
    const intercomElement = document.getElementById('intercom-container');
    if (intercomElement) {
      document.getElementById('intercom-container').classList.add('d-none');
    }
  }

  ngOnDestroy() {
    this.authToken.tokenStream.unsubscribe();
    this.userServiceSubscription.unsubscribe();
  }

}
