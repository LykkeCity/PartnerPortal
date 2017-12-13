import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { IntercomModule } from 'ng-intercom';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { Angulartics2Module } from 'angulartics2';
import { Angulartics2GoogleAnalytics } from 'angulartics2/ga';

import { IntercomService } from './services/intercom.service';
import { HomeModule } from './home/home.module';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { NotificationsModule } from './notifications/notifications.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    CoreModule.forRoot(),
    IntercomModule.forRoot({
      appId: 'n1npujem',
      updateOnRouterChange: true
    }),
    Angulartics2Module.forRoot([Angulartics2GoogleAnalytics]),
    HomeModule,
    NotificationsModule
  ],
  providers: [ IntercomService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
