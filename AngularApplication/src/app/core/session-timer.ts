import { Injectable } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap';
import { SessionExpireNotificationComponent } from '../notifications/global-notification/session-expire-notification/session-expire-notification.component';

@Injectable()
export class SessionTimer {

  private intervalID: any;
  private interval: number;

  constructor(private modalService: BsModalService) {
    this.interval = 300000; // 5 minutes session are 300 000 milliseconds
  }

  public startTimer(): void {
    this.intervalID = setInterval(() => {
      this.onSessionEnd();
    }, this.interval);
  }

  public resetTimer(): void {
    this.stopTimer();
    this.startTimer();
  }

  public stopTimer(): void {
    clearInterval(this.intervalID);
  }

  private onSessionEnd(): void {
    this.stopTimer();
    this.modalService.show(SessionExpireNotificationComponent, {
      keyboard: false,
      ignoreBackdropClick: true,
      class: 'session-expire-modal modal-sm'
    });
  }
}
