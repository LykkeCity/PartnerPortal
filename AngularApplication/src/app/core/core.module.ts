import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsletterSubscriptionService } from './newsletter-subscription.service';
import { AuthService } from './auth.service';
import { AuthGuard } from './auth.guard';
import { LoginRedirectGuard } from './login-redirect.guard';

@NgModule({
  imports: [
    CommonModule
  ]
})
export class CoreModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [
        AuthGuard,
        AuthService,
        LoginRedirectGuard,
        NewsletterSubscriptionService
      ]
    };
  }

  constructor (
    @Optional() @SkipSelf() parentModule: CoreModule,
  ) {
    // throw in case someone wrongly imports this module twice
    if (parentModule) {
      throw new Error(
        'CoreModule is already loaded. Import it in the AppModule only');
    }
  }
}
