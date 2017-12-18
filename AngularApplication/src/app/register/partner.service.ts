import {Injectable} from '@angular/core';
import {AuthRequestService} from '../core/auth-request.service';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class PartnerService {

  constructor(private authRequestService: AuthRequestService) {

  }

  public getPartnerData(email: string): Observable<any> {
    return this.authRequestService.get('/partners?clientEmail=' + email);
  }

  public registerPartner(partnerData: object): Observable<any> {
    return this.authRequestService.post('/partners', partnerData);
  }

  public isVerifiedPartner(email: string): Observable<any> {
    return this.authRequestService.get('/partners/status?clientEmail=' + email);
  }
}
