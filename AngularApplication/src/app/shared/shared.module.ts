import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { NewsletterComponent } from './components/newsletter/newsletter.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  declarations: [
    FooterComponent,
    NewsletterComponent
  ],
  exports: [
    FooterComponent,
    NewsletterComponent
  ]
})
export class SharedModule { }
