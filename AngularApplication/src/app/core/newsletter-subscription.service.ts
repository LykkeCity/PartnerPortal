import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class NewsletterSubscriptionService {

  constructor(private http: HttpClient) { }

  makeSubscription(newsletterInfo: object): Observable<any> {
    return this.http.post(
      '/api/newsLetter',
      Object.assign({}, newsletterInfo, {source: 'PartnerPortal'}),
      { responseType: 'text' }
    );
  }

}
