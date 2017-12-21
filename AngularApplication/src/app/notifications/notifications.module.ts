import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlobalNotificationComponent } from './global-notification/global-notification.component';
import { UnauthorizedNotificationComponent } from './global-notification/unauthorized-notification/unauthorized-notification.component';
import { NotificationsService } from './notifications.service';
import { SignoutNotificationComponent } from './global-notification/signout-notification/signout-notification.component';
import { SessionExpireNotificationComponent } from './global-notification/session-expire-notification/session-expire-notification.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ GlobalNotificationComponent, UnauthorizedNotificationComponent, SignoutNotificationComponent, SessionExpireNotificationComponent ],
  providers: [ NotificationsService ],
  exports: [ GlobalNotificationComponent ],
  entryComponents: [ UnauthorizedNotificationComponent, SignoutNotificationComponent ]
})
export class NotificationsModule { }
