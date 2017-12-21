import { Component, OnDestroy, OnInit } from '@angular/core';
import { IntercomService } from './services/intercom.service';
import { BsModalService } from 'ngx-bootstrap';
import { Subscription } from 'rxjs/Subscription';
import { NavigationStart, Router } from '@angular/router';
import { SessionTimer } from './core/session-timer';


@Component({
  selector: 'lpp-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {

  private modalShowSubscription: Subscription;
  private modalHideSubscription: Subscription;


  constructor(private intercom: IntercomService,
              private bsModalService: BsModalService,
              private router: Router,
              private sessionTimer: SessionTimer) {

    this.router.events.filter(e => e instanceof NavigationStart).subscribe(() => {
      this.sessionTimer.resetTimer();
    });
  }

  ngOnInit() {
    this.intercom.initIntercom();

    this.modalShowSubscription = this.bsModalService.onShow.subscribe(
      () => this.intercom.hideIntercomLauncher()
    );
    this.modalHideSubscription = this.bsModalService.onHide.subscribe(
      () => this.intercom.showIntercomLauncher()
    );
  }

  ngOnDestroy() {
    this.modalShowSubscription.unsubscribe();
    this.modalHideSubscription.unsubscribe();
  }
}
