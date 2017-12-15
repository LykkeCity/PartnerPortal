import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Location} from '@angular/common';
import {RegisterService} from '../register.service';

@Component({
  selector: 'lpp-register-partner',
  templateUrl: './register-partner.component.html',
  styleUrls: ['./register-partner.component.scss']
})
export class RegisterPartnerComponent {

  partnerForm: FormGroup;
  complianceForm: FormGroup;
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
      help: [''],
      regulations: ['', {validators: Validators.required, updateOn: 'submit'}]
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

  nextStep(): void {
    this.partnerForm.markAsDirty();
    if (this.partnerForm.invalid) {
      return;
    }

    this.currentStep = 'compliance';
  }

  onSubmit(): void {
    this.complianceForm.markAsDirty();
    if (this.complianceForm.invalid) {
      return;
    }

    this.registerService.registerPartner(this.partnerForm.value);
  }
}
