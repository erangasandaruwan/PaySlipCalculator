import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaySlipViewerComponent } from './pay-slip-viewer.component';

describe('PaySlipViewerComponent', () => {
  let component: PaySlipViewerComponent;
  let fixture: ComponentFixture<PaySlipViewerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaySlipViewerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PaySlipViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
