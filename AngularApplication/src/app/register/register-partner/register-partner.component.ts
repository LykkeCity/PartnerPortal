import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { PartnerService } from '../partner.service';
import { UserService } from '../../core/user.service';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/add/operator/finally';

@Component({
  selector: 'lpp-register-partner',
  templateUrl: './register-partner.component.html',
  styleUrls: ['./register-partner.component.scss']
})
export class RegisterPartnerComponent implements OnDestroy {

  partnerForm: FormGroup;
  currentStep: string;
  sub: Subscription;

  constructor(private formBuilder: FormBuilder,
              private location: Location,
              private partnerService: PartnerService,
              private usersService: UserService) {
    this.currentStep = 'partner';

    this.partnerForm = this.formBuilder.group({
      salutation: ['', {updateOn: 'submit'}],
      firstName: ['', {validators: Validators.required, updateOn: 'submit'}],
      lastName: ['', {validators: Validators.required, updateOn: 'submit'}],
      jobTitle: ['', {validators: Validators.required, updateOn: 'submit'}],
      organizationName: ['', {validators: Validators.required, updateOn: 'submit'}],
      street: ['', {validators: Validators.required, updateOn: 'submit'}],
      city: ['', {validators: Validators.required, updateOn: 'submit'}],
      zip: ['', {updateOn: 'submit'}],
      country: ['', {validators: Validators.required, updateOn: 'submit'}],
      phone: ['', {validators: Validators.required, updateOn: 'submit'}],
      email: ['', {validators: [Validators.required, Validators.email], updateOn: 'submit'}],
      website: ['', {updateOn: 'submit'}],
      aboutUs: ['', {updateOn: 'submit'}],
      primaryRelationship: ['', {validators: Validators.required, updateOn: 'submit'}],
      proposalConcern: ['', {validators: Validators.required, updateOn: 'submit'}],
      description: ['', {updateOn: 'submit'}]
    });
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
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
      const partnerData = {...this.partnerForm.value, clientEmail: this.usersService.userInfo.getValue()['Email']};
      this.sub = this.partnerService.registerPartner(partnerData).finally(() => {
        this.currentStep = 'finish';
      }).subscribe();
    }
  }
}
