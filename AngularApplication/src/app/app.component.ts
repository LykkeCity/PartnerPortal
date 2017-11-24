import { Component, OnInit } from '@angular/core';
import { Intercom } from 'ng-intercom';


@Component({
  selector: 'lpp-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  constructor(private intercom: Intercom) {

  }

  ngOnInit() {
    this.intercom.boot({
      app_id: "n1npujem"
    });
  }
}
