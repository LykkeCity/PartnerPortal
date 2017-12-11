import { Component, ElementRef, OnInit } from '@angular/core';
import { Angulartics2 } from 'angulartics2';
import { BsModalService } from 'ngx-bootstrap';
import { ContactUsPopupComponent } from './contact-us/contact-us-popup/contact-us-popup.component';

@Component({
  selector: 'lpp-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private modalService: BsModalService,
              private ga: Angulartics2,
              private elRef: ElementRef) {
  }

  ngOnInit() {
  }

  openModal(): void {
    this.ga.eventTrack.next({
      action: 'Click on Contact us button',
      properties: {category: 'Partner Portal Landing page'}
    });
    this.modalService.show(ContactUsPopupComponent, { class: 'contact-us-modal modal-lg' });
  }

  scrollToSection(selector: string): void {
    const element = this.elRef.nativeElement.querySelector(selector);
    window.scrollTo({left: 0, top: element.offsetTop - 90, behavior: 'smooth'});
  }
}
