import { Injectable } from '@angular/core';
import { AuthRequestService } from './auth-request.service';

@Injectable()
export class UserService {

  constructor(
    private authRequest: AuthRequestService
  ) { }

  getUserInfo() {
    return this.authRequest.get('/PersonalData');
  }

}
