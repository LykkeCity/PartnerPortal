import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AuthTokenService } from './auth-token.service';

@Injectable()
export class AuthRequestService {

  token: string;

  constructor(
    private http: HttpClient,
    private authToken: AuthTokenService
  ) {

    this.authToken.tokenStream.subscribe(
      token => {
        this.token = token;
      }
    );

  }

  public get(url: string, options?: object) {
    const reqUrl = environment.apiUrl + url;
    const headers = {
      'Authorization': 'Bearer ' + this.token
    };
    const reqOptions = Object.assign({}, options, {headers});

    return this.http.get(reqUrl, reqOptions);
  }

  public post(url: string, body: object = {}, options?: object) {
    const reqUrl = environment.apiUrl + url;
    const headers = {
      'Authorization': 'Bearer ' + this.token
    };
    const reqOptions = Object.assign({}, options, {headers});

    return this.http.post(reqUrl, body, reqOptions);
  }

}
