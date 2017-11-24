import { Component, OnInit } from '@angular/core';
import { Intercom } from 'ng-intercom';
import { Angulartics2GoogleAnalytics } from 'angulartics2/ga';


@Component({
  selector: 'lpp-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  constructor(private intercom: Intercom, angulartics2GoogleAnalytics: Angulartics2GoogleAnalytics) {

  }

  ngOnInit() {
    this.intercom.boot({
      app_id: "n1npujem"
    });
  }
}
