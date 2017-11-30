import { Component, ViewChild } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReCaptchaComponent } from 'angular2-recaptcha';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'lpp-contact-us-popup',
  templateUrl: './contact-us-popup.component.html',
  styleUrls: ['./contact-us-popup.component.scss']
})
export class ContactUsPopupComponent {

  contactUsForm: FormGroup;

  validCaptcha: boolean;
  @ViewChild(ReCaptchaComponent) captcha: ReCaptchaComponent;

  constructor(private bsModalRef: BsModalRef,
              private http: HttpClient,
              private formBuilder: FormBuilder) {
    this.contactUsForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      useCase: ['', Validators.required],
    });
  }

  get name() { return this.contactUsForm.get('name'); }
  get email() { return this.contactUsForm.get('email'); }
  get phone() { return this.contactUsForm.get('phone'); }
  get useCase() { return this.contactUsForm.get('useCase'); }

  handleCorrectCaptcha(): void {
    this.validCaptcha = true;
  }

  handleExpiredCaptcha(): void {
    this.validCaptcha = false;
  }

  onSubmit(event: any): void {
    event.preventDefault();
    if(this.contactUsForm.invalid) {
      return;
    }

    if (!this.validCaptcha && this.captcha) {
      this.captcha.reset();
      return;
    }

    this.http.post('/api/contacts/sendContact', JSON.stringify(Object.assign({}, this.contactUsForm.value, {source: "PartnerPortal"}))).subscribe(val => {
      this.bsModalRef.hide();
      //TODO show success message here
    });
  }
}
