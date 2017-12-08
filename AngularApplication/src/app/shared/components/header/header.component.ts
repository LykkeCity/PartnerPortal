import { Component, ElementRef, OnInit } from '@angular/core';
import { AuthService } from '../../../core/auth.service';

@Component({
  selector: 'lpp-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(
    private elRef: ElementRef,
    private auth: AuthService
  ) { }

  signIn() {
    this.auth.login();
  }

  scrollToSection(selector: string): void {
    const element = <HTMLElement>document.querySelector(selector);
    if (element) {
      window.scrollTo({left: 0, top: element.offsetTop - 90, behavior: 'smooth'});
    }
  }

  ngOnInit() {
  }

}
