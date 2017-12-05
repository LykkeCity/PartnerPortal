import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HomeService {

  constructor(private http: HttpClient) { }

  getChartData(assetId) {
    return this.http.get(
      `assets/data/${assetId}USD.json`
    );
  }

  sendContactUs(contactFormData) {
    return this.http.post(
      '/api/contacts/sendContact',
      Object.assign({}, contactFormData, {source: 'PartnerPortal'}),
      { responseType: 'text' }
    );
  }

}
