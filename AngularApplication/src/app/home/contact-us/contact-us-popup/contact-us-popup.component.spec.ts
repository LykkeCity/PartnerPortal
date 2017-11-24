import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactUsPopupComponent } from './contact-us-popup.component';

describe('ContactUsPopupComponent', () => {
  let component: ContactUsPopupComponent;
  let fixture: ComponentFixture<ContactUsPopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ContactUsPopupComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactUsPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
