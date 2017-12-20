import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxCarouselModule } from 'ngx-carousel';
import 'hammerjs';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { ContactUsPopupComponent } from './home/contact-us/contact-us-popup/contact-us-popup.component';
import { ModalModule } from 'ngx-bootstrap';
import { ReCaptchaModule } from 'angular2-recaptcha';
import { ReactiveFormsModule } from '@angular/forms';
import { HomeCarouselComponent } from './home/home-carousel/home-carousel.component';
import { NewsletterComponent } from './home/newsletter/newsletter.component';
import { HttpClientModule } from '@angular/common/http';
import { Angulartics2Module } from 'angulartics2';
import { Angulartics2GoogleAnalytics } from 'angulartics2/ga';
import { HomeChartComponent } from './home/home-chart/home-chart.component';
import { HomeChartService } from './home/home-chart/home-chart.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeCarouselComponent,
    HomeChartComponent,
    NewsletterComponent,
    ContactUsPopupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxCarouselModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxCarouselModule,
    ReCaptchaModule,
    ModalModule.forRoot(),
    Angulartics2Module.forRoot([Angulartics2GoogleAnalytics])
  ],
  entryComponents: [
    ContactUsPopupComponent
  ],
  providers: [ HomeChartService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
