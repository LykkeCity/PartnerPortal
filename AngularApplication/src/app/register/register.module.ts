import {CommonModule} from '@angular/common';
import {NgModule} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {RegisterPartnerComponent} from './register-partner/register-partner.component';


@NgModule({
  declarations: [
    RegisterPartnerComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
})
export class RegisterModule {
}
