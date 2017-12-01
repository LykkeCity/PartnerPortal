import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReCaptchaComponent } from 'angular2-recaptcha';
import { BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'lpp-contact-us-popup',
  templateUrl: './contact-us-popup.component.html',
  styleUrls: ['./contact-us-popup.component.scss']
})
export class ContactUsPopupComponent {

  contactUsForm: FormGroup;
  showSuccessMessage: boolean;
  ready: boolean = true;

  validCaptcha: boolean;
  @ViewChild(ReCaptchaComponent) captcha: ReCaptchaComponent;

  constructor(private bsModalRef: BsModalRef,
              private http: HttpClient,
              private formBuilder: FormBuilder) {
    this.contactUsForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      message: ['', Validators.required],
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

  onSubmit(event: any): void {
    event.preventDefault();
    if (this.contactUsForm.invalid) {
      return;
    }

    if (!this.validCaptcha && this.captcha) {
      this.captcha.reset();
      return;
    }

    this.ready = false;
    this.http.post('/api/contacts/sendContact', Object.assign({}, this.contactUsForm.value, {source: 'PartnerPortal'}), {responseType: 'text'}).subscribe(val => {
      this.ready = true;
      this.showSuccessMessage = true;
    });
  }
}
