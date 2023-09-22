import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FailurePaymentPageComponent } from './failure-payment-page.component';

describe('FailurePaymentPageComponent', () => {
  let component: FailurePaymentPageComponent;
  let fixture: ComponentFixture<FailurePaymentPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FailurePaymentPageComponent]
    });
    fixture = TestBed.createComponent(FailurePaymentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
