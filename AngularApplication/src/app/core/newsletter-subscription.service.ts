import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import {NewsletterInfo} from '../shared/components/newsletter/model/newsletter-info';

@Injectable()
export class NewsletterSubscriptionService {

  constructor(private http: HttpClient) { }

  makeSubscription(newsletterInfo: NewsletterInfo): Observable<string> {
    return this.http.post(
      '/api/newsLetter',
      {...newsletterInfo, source: 'PartnerPortal'},
      { responseType: 'text' }
    );
  }

}
