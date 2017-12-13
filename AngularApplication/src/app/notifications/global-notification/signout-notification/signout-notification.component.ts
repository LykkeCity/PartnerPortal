import { Component } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'lpp-signout-notification',
  templateUrl: './signout-notification.component.html',
  styleUrls: ['./signout-notification.component.scss']
})
export class SignoutNotificationComponent {

  constructor(public bsModalRef: BsModalRef) { }

}
