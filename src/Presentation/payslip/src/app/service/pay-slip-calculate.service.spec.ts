import { TestBed } from '@angular/core/testing';

import { PaySlipCalculateService } from './pay-slip-calculate.service';

describe('PaySlipCalculateService', () => {
  let service: PaySlipCalculateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PaySlipCalculateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
