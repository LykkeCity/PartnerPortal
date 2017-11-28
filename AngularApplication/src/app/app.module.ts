import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgxCarouselModule } from 'ngx-carousel';
import 'hammerjs';


import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeCarouselComponent } from './home/home-carousel/home-carousel.component';
import { NewsletterComponent } from './home/newsletter/newsletter.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HomeCarouselComponent,
    NewsletterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxCarouselModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
