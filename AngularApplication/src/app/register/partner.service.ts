import { Injectable } from '@angular/core';
import { AuthRequestService } from '../core/auth-request.service';
import { Observable } from 'rxjs/Observable';
import { PartnerData } from './models/partner-data';
import { PartnerStatus } from './models/partner-status';

@Injectable()
export class PartnerService {

  constructor(private authRequestService: AuthRequestService) {

  }

  public getPartnerData(email: string): Observable<PartnerData> {
    return this.authRequestService.get('/partners?clientEmail=' + email);
  }

  public registerPartner(partnerData: PartnerData): Observable<string> {
    return this.authRequestService.post('/partners', partnerData);
  }

  public isVerifiedPartner(email: string): Observable<PartnerStatus> {
    return this.authRequestService.get('/partners/status?clientEmail=' + email);
  }
}
