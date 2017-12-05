import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReCaptchaComponent } from 'angular2-recaptcha';
import { BsModalRef } from 'ngx-bootstrap';
import { HomeService } from '../../home.service';

@Component({
  selector: 'lpp-contact-us-popup',
  templateUrl: './contact-us-popup.component.html',
  styleUrls: ['./contact-us-popup.component.scss']
})
export class ContactUsPopupComponent {

  contactUsForm: FormGroup;
  showSuccessMessage: boolean;
  ready = true;

  validCaptcha: boolean;
  @ViewChild(ReCaptchaComponent) captcha: ReCaptchaComponent;

  constructor(private bsModalRef: BsModalRef,
              private formBuilder: FormBuilder,
              private homeService: HomeService) {

    this.contactUsForm = this.formBuilder.group({
      fullName: ['', { validators: Validators.required, updateOn: 'submit' }],
      email: ['', { validators: [ Validators.required, Validators.email ], updateOn: 'submit' }],
      phoneNumber: ['', { validators: Validators.required, updateOn: 'submit' }],
      message: ['', { validators: Validators.required, updateOn: 'submit' }],
    });

  }

  get fullName() {
    return this.contactUsForm.get('fullName');
  }

  get email() {
    return this.contactUsForm.get('email');
  }

  get phoneNumber() {
    return this.contactUsForm.get('phoneNumber');
  }

  get message() {
    return this.contactUsForm.get('message');
  }

  handleCorrectCaptcha(): void {
    this.validCaptcha = true;
  }

  handleExpiredCaptcha(): void {
    this.validCaptcha = false;
  }

  closeModal(): void {
    this.bsModalRef.hide();
  }

  onSubmit(): void {
    this.contactUsForm.markAsDirty();
    if (this.contactUsForm.invalid) {
      return;
    }

    if (!this.validCaptcha && this.captcha) {
      this.captcha.reset();
      return;
    }

    this.ready = false;
    this.homeService.sendContactUs(this.contactUsForm.value)
    .subscribe(
      val => {
        this.ready = true;
        this.showSuccessMessage = true;
      },
      error => {
        this.ready = true;
        alert('An error has occurred. We are sorry for the inconvenience.');
      }
    );
  }
}
