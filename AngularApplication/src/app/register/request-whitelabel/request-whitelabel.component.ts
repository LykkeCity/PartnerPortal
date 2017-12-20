import { Component, OnDestroy } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { PartnerService } from '../partner.service';
import { UserService } from '../../core/user.service';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/add/operator/finally';

@Component({
  selector: 'lpp-request-whitelabel',
  templateUrl: './request-whitelabel.component.html',
  styleUrls: ['./request-whitelabel.component.scss']
})
export class RequestWhitelabelComponent implements OnDestroy {

  isRegistered = false;
  ready = false;
  sub: Subscription;

  constructor(private bsModalRef: BsModalRef, private router: Router,
              private registerService: PartnerService,
              private usersService: UserService) {
    this.sub = this.registerService.isVerifiedPartner(this.usersService.userInfo.getValue()['Email'])
      .finally(() => {
        this.ready = true;
      }).subscribe(val => {
        this.isRegistered = val.status !== 400;
      });
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  closeModal(): void {
    this.bsModalRef.hide();
    if (!this.isRegistered) {
      this.router.navigateByUrl('register');
    }
  }
}
