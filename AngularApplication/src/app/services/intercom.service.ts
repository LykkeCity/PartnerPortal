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
    const intercomElement = document.getElementById('intercom-container');
    if (intercomElement) {
      intercomElement.classList.remove('d-none');
    }
  }

  hideIntercomLauncher() {
    const intercomElement = document.getElementById('intercom-container');
    if (intercomElement) {
      document.getElementById('intercom-container').classList.add('d-none');
    }
  }

}
