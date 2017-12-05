import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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

  onSubmit(event: any) {

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
        this.showErrorMessage = true;
        this.ready = true;
      }
    );
  }
}
