import {Injectable} from '@angular/core';
import {AuthRequestService} from '../core/auth-request.service';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class RegisterService {

  constructor(private authRequestService: AuthRequestService) {

  }

  public registerPartner(partnerData: object): Observable<any> {
    return this.authRequestService.post('partners/register', partnerData);
  }

}
