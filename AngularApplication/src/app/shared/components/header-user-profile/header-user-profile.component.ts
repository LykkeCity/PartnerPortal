import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';

import { AuthService } from '../../../core/auth.service';
import { UserService } from '../../../core/user.service';

@Component({
  selector: 'lpp-header-user-profile',
  templateUrl: './header-user-profile.component.html',
  styleUrls: ['./header-user-profile.component.scss']
})
export class HeaderUserProfileComponent implements OnInit, OnDestroy {

  userServiceSub: Subscription;

  constructor(
    private auth: AuthService,
    private userService: UserService
  ) {}

  signOut() {
    this.auth.logout();
  }

  ngOnInit() {
    // Subscribed to the UserService.getUserInfo() just to trigger an test an authenticated request
    this.userServiceSub = this.userService.getUserInfo().subscribe();
  }

  ngOnDestroy() {
    this.userServiceSub.unsubscribe();
  }
}
