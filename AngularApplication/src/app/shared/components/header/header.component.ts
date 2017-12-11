import { Component, ElementRef, OnInit } from '@angular/core';
import { AuthTokenService } from '../../../core/auth-token.service';
import { AuthService } from '../../../core/auth.service';

@Component({
  selector: 'lpp-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  isAuthenticated = false;

  constructor(
    private elRef: ElementRef,
    private auth: AuthService,
    private authToken: AuthTokenService,
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
    this.authToken.tokenStream.subscribe(
      token => { this.isAuthenticated = !!token; }
    );
  }

}
