import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import {Router} from '@angular/router';

@Component({
  selector: 'lpp-request-whitelabel',
  templateUrl: './request-whitelabel.component.html',
  styleUrls: ['./request-whitelabel.component.scss']
})
export class RequestWhitelabelComponent implements OnInit {

  constructor(private bsModalRef: BsModalRef, private router: Router) { }

  ngOnInit() {
  }

  closeModal(): void {
    this.bsModalRef.hide();
    this.router.navigateByUrl('register');
  }
}
