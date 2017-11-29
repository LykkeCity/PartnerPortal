import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HomeChartService {

  constructor(private http: HttpClient) { }

  getChartData(assetId) {
    return this.http.get(
      `assets/data/${assetId}USD.json`
    );
  }
}
