import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'lpp-newsletter',
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.scss']
})
export class NewsletterComponent implements OnInit {

  newsletterForm: FormGroup;
  email: string;
  constructor(private formBuilder: FormBuilder) { }

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


  }
}
