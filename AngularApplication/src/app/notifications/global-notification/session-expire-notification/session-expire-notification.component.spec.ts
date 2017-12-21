import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionExpireNotificationComponent } from './session-expire-notification.component';

describe('SessionExpireNotificationComponent', () => {
  let component: SessionExpireNotificationComponent;
  let fixture: ComponentFixture<SessionExpireNotificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SessionExpireNotificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SessionExpireNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
