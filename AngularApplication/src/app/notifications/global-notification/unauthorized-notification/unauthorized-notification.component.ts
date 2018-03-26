import { Component } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { AuthService } from '../../../core/auth.service';

@Component({
  selector: 'lpp-unauthorized-notification',
  templateUrl: './unauthorized-notification.component.html',
  styleUrls: ['./unauthorized-notification.component.scss']
})
export class UnauthorizedNotificationComponent {

  constructor(public modalRef: BsModalRef, private auth: AuthService) { }

  login() {
    this.auth.login();
  }

}
