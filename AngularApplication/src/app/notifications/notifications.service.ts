import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { NotificationMessage } from './notification-message';

@Injectable()
export class NotificationsService {

  messageStream = new BehaviorSubject<NotificationMessage | null>(null);

  constructor() { }

}
