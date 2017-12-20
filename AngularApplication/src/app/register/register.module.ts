import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterPartnerComponent } from './register-partner/register-partner.component';
import { RequestWhitelabelComponent } from './request-whitelabel/request-whitelabel.component';
import { PartnerService } from './partner.service';
import { RegisterRootComponent } from './register-root/register-root.component';
import { RouterModule } from '@angular/router';
import { RegisterRoutingModule } from './register-routing.module';


@NgModule({
  declarations: [
    RegisterRootComponent,
    RegisterPartnerComponent,
    RequestWhitelabelComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    RegisterRoutingModule
  ],
  providers: [PartnerService],
  entryComponents: [RequestWhitelabelComponent]
})
export class RegisterModule {
}
