import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTypeComponent } from './create-type.component';

describe('CreateTypeComponent', () => {
  let component: CreateTypeComponent;
  let fixture: ComponentFixture<CreateTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateTypeComponent]
    });
    fixture = TestBed.createComponent(CreateTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
