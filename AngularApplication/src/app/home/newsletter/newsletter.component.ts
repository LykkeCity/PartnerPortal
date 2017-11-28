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
  email: string;
  constructor(private formBuilder: FormBuilder, private http: HttpClient) { }

  ngOnInit() {
    this.newsletterForm = this.formBuilder.group({
      email: ['', Validators.required]
    });
  }

  get formEmail() { return this.newsletterForm.get('email'); }

  onSubmit(event: any) {
    event.preventDefault();

    if(this.newsletterForm.invalid) {
      return;
    }

    this.http.post('', JSON.stringify({email: this.email})).subscribe(val => {

    });
  }
}