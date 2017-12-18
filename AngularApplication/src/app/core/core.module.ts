import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsletterSubscriptionService } from './newsletter-subscription.service';
import { AuthService } from './auth.service';
import { AuthGuard } from './auth.guard';
import { LoginRedirectGuard } from './login-redirect.guard';
import { UserService } from './user.service';
import { AuthRequestService } from './auth-request.service';
import { UnauthorizedInterceptorService } from './unauthorized-interceptor.service';
import { AuthTokenService } from './auth-token.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {RegisterGuard} from './register.guard';

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
        AuthRequestService,
        AuthService,
        AuthTokenService,
        LoginRedirectGuard,
        NewsletterSubscriptionService,
        UserService,
        UnauthorizedInterceptorService,
        {
          provide: HTTP_INTERCEPTORS,
          useClass: UnauthorizedInterceptorService,
          multi: true,
        },
        RegisterGuard
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
