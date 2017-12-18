import {Component} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {Location} from '@angular/common';
import {RegisterService} from '../register.service';

@Component({
  selector: 'lpp-register-partner',
  templateUrl: './register-partner.component.html',
  styleUrls: ['./register-partner.component.scss']
})
export class RegisterPartnerComponent {

  partnerForm: FormGroup;
  currentStep: string;

  constructor(private formBuilder: FormBuilder,
              private location: Location,
              private registerService: RegisterService) {
    this.currentStep = 'partner';

    this.partnerForm = this.formBuilder.group({
      salutation: [''],
      firstName: ['', {validators: Validators.required, updateOn: 'submit'}],
      lastName: ['', {validators: Validators.required, updateOn: 'submit'}],
      jobTitle: ['', {validators: Validators.required, updateOn: 'submit'}],
      organizationName: ['', {validators: Validators.required, updateOn: 'submit'}],
      street: ['', {validators: Validators.required, updateOn: 'submit'}],
      city: ['', {validators: Validators.required, updateOn: 'submit'}],
      zip: [''],
      country: ['', {validators: Validators.required, updateOn: 'submit'}],
      phone: ['', {validators: Validators.required, updateOn: 'submit'}],
      email: ['', {validators: Validators.required, updateOn: 'submit'}],
      website: [''],
      aboutUs: [''],
      relationship: ['', {validators: Validators.required, updateOn: 'submit'}],
      category: ['', {validators: Validators.required, updateOn: 'submit'}],
      help: ['']
    });
  }

  setSalutationValue(value: string) {
    this.partnerForm.controls['salutation'].setValue(value);
  }

  get salutation() {
    return this.partnerForm.get('salutation').value;
  }

  returnToPreviousPage() {
    this.location.back();
  }

  isFormValid(): boolean {
    this.partnerForm.markAsDirty();
    return !this.partnerForm.invalid;
  }

  processForm(): void {
    if (this.currentStep === 'partner') {
      this.nextStep();
    } else {
      this.onSubmit();
    }
  }

  nextStep(): void {
    if (this.isFormValid()) {
      this.partnerForm.addControl('supportedRegulations', new FormControl('', {validators: Validators.required, updateOn: 'submit'}));
      this.partnerForm.markAsPristine();
      this.currentStep = 'compliance';
    }
  }

  onSubmit(): void {
    if (this.isFormValid()) {
      this.registerService.registerPartner(this.partnerForm.value);
      this.currentStep = 'finish';
    }
  }
}
