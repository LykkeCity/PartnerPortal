import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeChartComponent } from './home-chart/home-chart.component';
import { HomeCarouselComponent } from './home-carousel/home-carousel.component';
import { NgxCarouselModule } from 'ngx-carousel';
import { ContactUsPopupComponent } from './contact-us/contact-us-popup/contact-us-popup.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ReCaptchaModule } from 'angular2-recaptcha';
import 'hammerjs';
import { HomeService } from './home.service';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    NgxCarouselModule,
    ReactiveFormsModule,
    ReCaptchaModule,
    NgxCarouselModule,
  ],
  declarations: [
    HomeComponent,
    HomeCarouselComponent,
    HomeChartComponent,
    ContactUsPopupComponent
  ],
  providers: [ HomeService ],
  entryComponents: [ ContactUsPopupComponent ]
})
export class HomeModule { }
