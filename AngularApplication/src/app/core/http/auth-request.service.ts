import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {AuthTokenService} from '../auth-token.service';
import {catchError} from 'rxjs/operators';
import {Router} from '@angular/router';
import {of as observableOf} from 'rxjs/observable/of';
import {NotificationsService} from '../../notifications/notifications.service';
import {NotificationMessage} from '../../notifications/notification-message';
import {GetRequestOptions, PostRequestOptions} from './request-options';

@Injectable()
export class AuthRequestService {

  token: string;

  constructor(private http: HttpClient,
              private authToken: AuthTokenService,
              private notifications: NotificationsService,
              private router: Router) {

    this.authToken.tokenStream.subscribe(
      token => {
        this.token = token;
      }
    );

  }

  public get(options: GetRequestOptions) {
    const reqUrl = this.buildUrl(options);

    const headers = {
      'Authorization': 'Bearer ' + this.token
    };
    const reqOptions = Object.assign({}, options.opts, {headers});

    return this.http.get(reqUrl, reqOptions).pipe(
      catchError(error => this.handleError(error))
    );
  }

  public post(options: PostRequestOptions) {
    const reqUrl = this.buildUrl(options);

    const headers = {
      'Authorization': 'Bearer ' + this.token
    };
    const reqOptions = Object.assign({}, options.opts, {headers});

    return this.http.post(reqUrl, options.body, reqOptions).pipe(
      catchError(error => this.handleError(error))
    );
  }

  private handleError(error) {

    const message: NotificationMessage = {
      event: 'api-error',
      status: error.status,
      message: error.message
    };
    if (error.status === 401) {
      this.router.navigateByUrl('');
      this.authToken.tokenStream.next(null);
    }
    this.notifications.messageStream.next(message);
    return observableOf(error);
  }

  private buildUrl(options: GetRequestOptions | PostRequestOptions): string {
    let baseUrl = environment.apiUrl + options.url;

    if (options['getParams']) {
      baseUrl += '?' + this.buildGetParams(options['getParams']);
    }

    return baseUrl;
  }

  private buildGetParams(params: object): string {
    let result = '';

    for (const prop in params) {
      if (params.hasOwnProperty(prop)) {
        if (result) {
          result += '&';
        }

        result += encodeURIComponent(prop) + '=' + encodeURIComponent(params[prop]);
      }
    }

    return result;
  }

}
