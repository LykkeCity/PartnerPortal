import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxCarouselModule } from 'ngx-carousel';
import 'hammerjs';

import { IntercomModule } from 'ng-intercom';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { ContactUsPopupComponent } from './home/contact-us/contact-us-popup/contact-us-popup.component';
import { ModalModule } from 'ngx-bootstrap';
import { ReCaptchaModule } from 'angular2-recaptcha';
import { ReactiveFormsModule } from '@angular/forms';
import { HomeCarouselComponent } from './home/home-carousel/home-carousel.component';
import { NewsletterComponent } from './home/newsletter/newsletter.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeCarouselComponent,
    NewsletterComponent,
    HomeCarouselComponent,
    ContactUsPopupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxCarouselModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxCarouselModule,
    IntercomModule.forRoot({
      appId: "n1npujem",
      updateOnRouterChange: true
    }),
    ReCaptchaModule,
    ModalModule.forRoot()
  ],
  entryComponents: [
    ContactUsPopupComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
