import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/auth.service';
import { BsModalRef} from 'ngx-bootstrap';

@Component({
  selector: 'lpp-session-expire-notification',
  templateUrl: './session-expire-notification.component.html',
  styleUrls: ['./session-expire-notification.component.scss']
})
export class SessionExpireNotificationComponent implements OnInit {

  expired = false;
  seconds = 10;
  interval: any;

  constructor(private authService: AuthService, private bsModalService: BsModalRef) {
  }

  ngOnInit() {
    this.startInterval();
  }

  startInterval(): void {
    clearInterval(this.interval);

    this.interval = setInterval(() => {
      this.seconds--;
      if (this.seconds === 0) {
        this.authService.logout(false);
        this.expired = true;
        clearInterval(this.interval);
      }
    }, 1000);
  }

  login(): void {
    this.bsModalService.hide();
    this.authService.login();
  }

  logout(): void {
    this.bsModalService.hide();
    this.authService.logout(true);
  }
}
