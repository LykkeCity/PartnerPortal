import {Injectable} from '@angular/core';
import {AuthRequestService} from './auth-request.service';
import {map, tap} from 'rxjs/operators';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';

@Injectable()
export class UserService {

  userInfo = new BehaviorSubject<object | null>(null);

  constructor(private authRequest: AuthRequestService) {
  }

  getUserInfo() {
    return this.authRequest.get('/PersonalData').pipe(
      map(res => res['Result'])
    ).pipe(tap(res => {
      this.userInfo.next(res);
    }));
  }

}
