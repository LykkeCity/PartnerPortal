import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SignoutNotificationComponent } from './signout-notification.component';

describe('SignoutNotificationComponent', () => {
  let component: SignoutNotificationComponent;
  let fixture: ComponentFixture<SignoutNotificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SignoutNotificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SignoutNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
