import {Component, OnDestroy} from '@angular/core';
import {BsModalRef} from 'ngx-bootstrap';
import {Router} from '@angular/router';
import {PartnerService} from '../partner.service';
import {UserService} from '../../core/user.service';
import {Subscription} from 'rxjs/Subscription';

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
    this.sub = this.registerService.isVerifiedPartner(this.usersService.userInfo.getValue()['Email']).subscribe(val => {
      if (val.status === 400) {
        this.ready = true;
        this.isRegistered = false;
      } else {
        this.isRegistered = true;
        this.ready = true;
      }
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
