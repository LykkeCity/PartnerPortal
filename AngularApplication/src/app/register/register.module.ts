import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {RegisterPartnerComponent} from './register-partner/register-partner.component';
import { RequestWhitelabelComponent } from './request-whitelabel/request-whitelabel.component';
import {RegisterService} from './register.service';


@NgModule({
  declarations: [
    RegisterPartnerComponent,
    RequestWhitelabelComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  providers: [RegisterService],
  entryComponents: [RequestWhitelabelComponent]
})
export class RegisterModule {
}
