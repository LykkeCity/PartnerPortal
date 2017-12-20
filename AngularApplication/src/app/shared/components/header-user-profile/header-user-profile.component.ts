import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/auth.service';
import { UserService } from '../../../core/user.service';
import { BsModalService } from 'ngx-bootstrap';
import { RequestWhitelabelComponent } from '../../../register/request-whitelabel/request-whitelabel.component';

@Component({
  selector: 'lpp-header-user-profile',
  templateUrl: './header-user-profile.component.html',
  styleUrls: ['./header-user-profile.component.scss']
})
export class HeaderUserProfileComponent implements OnInit {

  constructor(private auth: AuthService,
              private userService: UserService,
              private modalService: BsModalService) {
  }

  signOut() {
    this.auth.logout();
  }

  ngOnInit() {
    this.userService.getUserInfo().subscribe();
  }

  openRegisterModal(): void {
    this.modalService.show(RequestWhitelabelComponent, {class: 'request-whitelabel-modal modal-sm'});
  }
}
