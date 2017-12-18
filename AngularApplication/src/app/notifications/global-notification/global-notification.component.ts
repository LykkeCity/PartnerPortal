import {Component, OnDestroy, OnInit} from '@angular/core';
import {filter} from 'rxjs/operators';
import {BsModalService} from 'ngx-bootstrap';
import {NotificationsService} from '../notifications.service';
import {NotificationMessage} from '../notification-message';
import {UnauthorizedNotificationComponent} from './unauthorized-notification/unauthorized-notification.component';
import {SignoutNotificationComponent} from './signout-notification/signout-notification.component';

@Component({
  selector: 'lpp-global-notification',
  templateUrl: './global-notification.component.html',
  styleUrls: ['./global-notification.component.scss']
})
export class GlobalNotificationComponent implements OnInit, OnDestroy {

  constructor(private modalService: BsModalService,
              private notifications: NotificationsService) {
  }

  ngOnInit() {
    this.notifications.messageStream.pipe(
      filter(message => !!message)
    ).subscribe(
      (message: NotificationMessage) => {

        // TODO: this should be refactored to avoid creation of many components only for messaging

        let component: any;
        if (message.status === 401) {
          component = UnauthorizedNotificationComponent;
        } else if (message.event === 'sign-out') {
          component = SignoutNotificationComponent;
        } else {
          // show generic error message
        }

        if (component) {
          this.modalService.show(component, {
            ignoreBackdropClick: true,
            keyboard: false,
            class: 'generic-message modal-dialog'
          });
        }
      }
    );
  }

  ngOnDestroy() {
    this.notifications.messageStream.unsubscribe();
  }

}
