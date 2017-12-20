import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { PartnerData } from './models/partner-data';
import { PartnerStatus } from './models/partner-status';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class PartnerService {

  constructor(private http: HttpClient) {

  }

  public getPartnerData(email: string): Observable<PartnerData> {
    return this.http.get<PartnerData>('/api/partners', {
      params: new HttpParams().append('clientEmail', email)
    });
  }

  public registerPartner(partnerData: PartnerData): Observable<PartnerData> {
    return this.http.post<PartnerData>('/api/partners', partnerData);
  }

  public getPartnerStatus(email: string): Observable<PartnerStatus> {
    return this.http.get('/api/partners/status', {
      params: new HttpParams().append('clientEmail', email)
    });
  }

  public isPartnerExisting(email: string): Observable<PartnerStatus> {
    return this.http.get('/api/partners/isExisting', {
      params: new HttpParams().append('clientEmail', email)
    });
  }
}
