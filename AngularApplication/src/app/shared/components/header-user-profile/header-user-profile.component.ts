import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/auth.service';
import { UserService } from '../../../core/user.service';

@Component({
  selector: 'lpp-header-user-profile',
  templateUrl: './header-user-profile.component.html',
  styleUrls: ['./header-user-profile.component.scss']
})
export class HeaderUserProfileComponent implements OnInit {

  constructor(
    private auth: AuthService,
    private userService: UserService
  ) {}

  signOut() {
    this.auth.logout();
  }

  ngOnInit() {
    this.userService.getUserInfo().subscribe();
  }
}
