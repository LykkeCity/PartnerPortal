import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { NewsletterComponent } from './components/newsletter/newsletter.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule, PopoverModule } from 'ngx-bootstrap';
import { HeaderComponent } from './components/header/header.component';
import { HeaderUserProfileComponent } from './components/header-user-profile/header-user-profile.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    PopoverModule.forRoot()
  ],
  declarations: [
    FooterComponent,
    NewsletterComponent,
    HeaderComponent,
    HeaderUserProfileComponent
  ],
  exports: [
    FooterComponent,
    NewsletterComponent,
    HeaderComponent,
    HeaderUserProfileComponent
  ]
})
export class SharedModule { }
