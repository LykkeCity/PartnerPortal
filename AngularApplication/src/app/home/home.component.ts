import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap';
import { ContactUsPopupComponent } from './contact-us/contact-us-popup/contact-us-popup.component';

@Component({
  selector: 'lpp-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private modalService: BsModalService) { }

  ngOnInit() {
  }

  openModal(): void {
    this.modalService.show(ContactUsPopupComponent);
  }
}
