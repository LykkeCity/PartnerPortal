import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsletterSubscriptionService } from './newsletter-subscription.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [ NewsletterSubscriptionService ]
})
export class CoreModule { }
