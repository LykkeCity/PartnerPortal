import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlobalNotificationComponent } from './global-notification/global-notification.component';
import { UnauthorizedNotificationComponent } from './global-notification/unauthorized-notification/unauthorized-notification.component';
import { NotificationsService } from './notifications.service';
import { SignoutNotificationComponent } from './global-notification/signout-notification/signout-notification.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ GlobalNotificationComponent, UnauthorizedNotificationComponent, SignoutNotificationComponent ],
  providers: [ NotificationsService ],
  exports: [ GlobalNotificationComponent ],
  entryComponents: [ UnauthorizedNotificationComponent, SignoutNotificationComponent ]
})
export class NotificationsModule { }
