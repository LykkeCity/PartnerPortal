import { Injectable } from '@angular/core';
import { AuthRequestService } from './auth-request.service';
import { map } from 'rxjs/operators';

@Injectable()
export class UserService {

  constructor(
    private authRequest: AuthRequestService
  ) { }

  getUserInfo() {
    return this.authRequest.get('/PersonalData').pipe(
      map( res => res['Result'] )
    );
  }

}
