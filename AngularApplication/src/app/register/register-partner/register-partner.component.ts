import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'lpp-register-partner',
  templateUrl: './register-partner.component.html',
  styleUrls: ['./register-partner.component.scss']
})
export class RegisterPartnerComponent implements OnInit {

  partnerForm: FormGroup;
  complianceForm: FormGroup;
  currentForm: string;

  @ViewChild('submitButton') submitButton: ElementRef;

  constructor(private formBuilder: FormBuilder) {
    this.currentForm = 'partner';

    this.partnerForm = this.formBuilder.group({
      salutation: [''],
      firstName: ['', { validators: Validators.required, updateOn: 'submit' }],
      lastName: ['', { validators: Validators.required, updateOn: 'submit' }],
      jobTitle: ['', { validators: Validators.required, updateOn: 'submit' }],
      organizationName: ['', { validators: Validators.required, updateOn: 'submit' }],
      street: ['', { validators: Validators.required, updateOn: 'submit' }],
      city: ['', { validators: Validators.required, updateOn: 'submit' }],
      zip: [''],
      country: ['', { validators: Validators.required, updateOn: 'submit' }],
      phone: ['', { validators: Validators.required, updateOn: 'submit' }],
      email: ['', { validators: Validators.required, updateOn: 'submit' }],
      website: [''],
      aboutUs: [''],
      relationship: ['', { validators: Validators.required, updateOn: 'submit' }],
      category: ['', { validators: Validators.required, updateOn: 'submit' }],
      help: [''],
    });

    this.complianceForm = this.formBuilder.group({
      regulations: ['', { validators: Validators.required, updateOn: 'submit' }]
    })
  }

  ngOnInit() {
  }

  setSalutationValue(value: string) {
    this.partnerForm.controls['salutation'].setValue(value);
  }

  get salutation() {
    return this.partnerForm.get('salutation').value;
  }

  nextStep(): void {
    this.partnerForm.markAsDirty();
    if(this.partnerForm.invalid) {
      let el:HTMLElement = this.submitButton.nativeElement as HTMLElement;
      el.click();
      return;
    }

    this.currentForm = 'compliance';
  }

  onSubmit(): void {
    this.complianceForm.markAsDirty();
    if(this.complianceForm.invalid) {
      return;
    }

    //TODO send this data to the API
   let data = Object.assign({}, this.complianceForm.value, this.partnerForm.value);
  }
}
