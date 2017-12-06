import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsletterSubscriptionService } from './newsletter-subscription.service';
import { AuthService } from './auth.service';
import { AuthGuard } from './auth.guard';
import { LoginRedirectGuard } from './login-redirect.guard';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    AuthGuard,
    AuthService,
    LoginRedirectGuard,
    NewsletterSubscriptionService
  ]
})
export class CoreModule { }
