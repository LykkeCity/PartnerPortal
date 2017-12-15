import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestWhitelabelComponent } from './request-whitelabel.component';

describe('RequestWhitelabelComponent', () => {
  let component: RequestWhitelabelComponent;
  let fixture: ComponentFixture<RequestWhitelabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestWhitelabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestWhitelabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
