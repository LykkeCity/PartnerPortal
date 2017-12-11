import { Injectable } from '@angular/core';
import { Intercom } from 'ng-intercom';

@Injectable()
export class IntercomService {

  constructor(
    private intercom: Intercom
  ) { }

  initIntercom() {
    this.intercom.boot();
  }

  showIntercomLauncher() {
    document.getElementById('intercom-container').classList.remove('d-none');
  }

  hideIntercomLauncher() {
    document.getElementById('intercom-container').classList.add('d-none');
  }

}
