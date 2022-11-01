import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaySlipCalculateComponent } from './pay-slip-calculate.component';

describe('PaySlipCalculateComponent', () => {
  let component: PaySlipCalculateComponent;
  let fixture: ComponentFixture<PaySlipCalculateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaySlipCalculateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaySlipCalculateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
