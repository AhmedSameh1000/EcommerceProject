import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccessPaymentPageComponent } from './success-payment-page.component';

describe('SuccessPaymentPageComponent', () => {
  let component: SuccessPaymentPageComponent;
  let fixture: ComponentFixture<SuccessPaymentPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SuccessPaymentPageComponent]
    });
    fixture = TestBed.createComponent(SuccessPaymentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
