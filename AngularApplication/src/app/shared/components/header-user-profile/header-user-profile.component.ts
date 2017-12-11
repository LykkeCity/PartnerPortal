import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserService } from '../../../core/user.service';
import { AuthService } from '../../../core/auth.service';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'lpp-header-user-profile',
  templateUrl: './header-user-profile.component.html',
  styleUrls: ['./header-user-profile.component.scss']
})
export class HeaderUserProfileComponent implements OnInit, OnDestroy {

  userInfo: object;
  userInfoSubscription: Subscription;

  constructor(
    private auth: AuthService,
    private userService: UserService
  ) {
    this.userInfoSubscription = this.userService.getUserInfo().subscribe(
      res => {
        this.userInfo = res['Result'];
      }
    );
  }

  signOut() {
    this.auth.logout();
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.userInfoSubscription.unsubscribe();
  }

}
