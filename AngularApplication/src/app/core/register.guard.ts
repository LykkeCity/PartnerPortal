import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs/Observable';
import {UserService} from './user.service';
import {PartnerService} from '../register/partner.service';
import {Observer} from 'rxjs/Observer';

@Injectable()
export class RegisterGuard implements CanActivate {

  constructor(private router: Router,
              private userService: UserService,
              private partnerService: PartnerService) {
  }

  canActivate(next: ActivatedRouteSnapshot,
              state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    return Observable.create((obs: Observer<boolean>) => {
      this.userService.getUserInfo().subscribe(val => {
        this.partnerService.isVerifiedPartner(val['Email']).subscribe(res => {
          if (res.status === 400) {
            obs.next(true);
          } else {
            this.router.navigateByUrl('');
            obs.next(false);
          }
        });
      });
    });
  }
}
