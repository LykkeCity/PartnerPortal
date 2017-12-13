import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnauthorizedNotificationComponent } from './unauthorized-notification.component';

describe('UnauthorizedNotificationComponent', () => {
  let component: UnauthorizedNotificationComponent;
  let fixture: ComponentFixture<UnauthorizedNotificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnauthorizedNotificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnauthorizedNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
