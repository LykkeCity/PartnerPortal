import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {ContactUsModel} from './contact-us/models/contact-us.model';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class HomeService {

  constructor(private http: HttpClient) { }

  getChartData(assetId) {
    return this.http.get(
      `assets/data/${assetId}USD.json`
    );
  }

  sendContactUs(contactFormData: ContactUsModel): Observable<string> {
    return this.http.post(
      '/api/contacts/sendContact',
      {...contactFormData, source: 'PartnerPortal'},
      { responseType: 'text' }
    );
  }

}
