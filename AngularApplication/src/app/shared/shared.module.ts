import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { NewsletterComponent } from './components/newsletter/newsletter.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  declarations: [
    FooterComponent,
    NewsletterComponent,
    HeaderComponent
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    NewsletterComponent
  ]
})
export class SharedModule { }
