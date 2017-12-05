import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NewsletterSubscriptionService } from '../../../core/newsletter-subscription.service';

@Component({
  selector: 'lpp-newsletter',
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.scss']
})
export class NewsletterComponent implements OnInit {

  newsletterForm: FormGroup;
  showSuccessMessage: boolean;
  showErrorMessage: boolean;
  ready = true;
  constructor(private formBuilder: FormBuilder, private newsletterService: NewsletterSubscriptionService) { }

  ngOnInit() {
    this.newsletterForm = this.formBuilder.group({
      email: ['', { validators: [ Validators.required, Validators.email ], updateOn: 'submit' }]
    });
  }

  get formEmail() { return this.newsletterForm.get('email'); }

  onChange() {
    this.showSuccessMessage = false;
    this.showErrorMessage = false;
  }

  onSubmit() {

    this.newsletterForm.markAsDirty();

    if (this.newsletterForm.invalid) {
      return;
    }

    this.ready = false;
    this.newsletterService.makeSubscription(this.newsletterForm.value)
    .subscribe(
      val => {
        this.showSuccessMessage = true;
        this.ready = true;
        this.newsletterForm.reset();
      },
      error => {
        if (error.status === 400) {
          this.showErrorMessage = true;
        } else {
          alert('An error has occurred. We are sorry for the inconvenience.');
        }
        this.ready = true;
      }
    );
  }
}
