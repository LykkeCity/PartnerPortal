import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'lpp-newsletter',
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.scss']
})
export class NewsletterComponent implements OnInit {

  newsletterForm: FormGroup;
  showSuccessMessage: boolean;
  showErrorMessage: boolean;
  ready: boolean = true;
  constructor(private formBuilder: FormBuilder, private http: HttpClient) { }

  ngOnInit() {
    this.newsletterForm = this.formBuilder.group({
      email: ['', Validators.required]
    });
  }

  get formEmail() { return this.newsletterForm.get('email'); }

  onChange() {
    this.showSuccessMessage = false;
    this.showErrorMessage = false;
  }

  onSubmit(event: any) {
    this.onChange();
    event.preventDefault();

    if(this.newsletterForm.invalid) {
      return;
    }

    this.ready = false;
    this.http.post('/api/newsLetter', Object.assign({}, this.newsletterForm.value, {source: 'PartnerPortal'}), {responseType: 'text'}
    ).subscribe(
      val => {
      this.showSuccessMessage = true;
        this.ready = true;
    },
      error => {
        this.showErrorMessage = true;
        this.ready = true;
    });
  }
}
