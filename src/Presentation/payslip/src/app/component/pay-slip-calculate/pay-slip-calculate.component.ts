import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder,  NgForm, Validators} from '@angular/forms';
import { catchError, map, Observable, take } from 'rxjs';
import { CalculatedPaySlip } from 'src/app/model/calculated-pay-slip';
import { KeyValuePair } from 'src/app/model/key-value-pair';
import { PaySlipInformation } from 'src/app/model/pay-slip-info';
import { DefinitionsService } from 'src/app/service/definitions.service';
import { PaySlipCalculateService } from 'src/app/service/pay-slip-calculate.service';

@Component({
  selector: 'app-pay-slip-calculate',
  templateUrl: './pay-slip-calculate.component.html',
  styleUrls: ['./pay-slip-calculate.component.css']
})
export class PaySlipCalculateComponent implements OnInit {

  monthDefinitions: KeyValuePair[] = [];
  calculatedPaySlip: CalculatedPaySlip | any;
  isShowPaySlip: boolean = false;

  paySlipFormGroup = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    payPeriod: ['', [Validators.required]],
    annualSalary: ['0.00', [Validators.required, Validators.min(0), Validators.max(50)]],
    superRate: ['0.00', [Validators.required, Validators.min(0), Validators.max(50)]],
  })

  constructor(
    private fb: FormBuilder,
    private formBuilder: FormBuilder, 
    private definitionService: DefinitionsService,
    private paySlipService: PaySlipCalculateService) {
  }

  ngOnInit(): void {
    this.isShowPaySlip = false;
    this.definitionService.getMonthsDefinitions()
      .pipe()
      .subscribe((defs: KeyValuePair[]) => {
        this.monthDefinitions = defs;
      });
  }

  calculatePaySlip() {
    try {

      let paySlipInformation = new PaySlipInformation(
        this.paySlipFormGroup.controls.firstName.value as string,
        this.paySlipFormGroup.controls.lastName.value as string,
        Number(this.paySlipFormGroup.controls.annualSalary.value),
        Number(this.paySlipFormGroup.controls.superRate.value),
        this.paySlipFormGroup.controls.payPeriod.value as string);

        this.paySlipService.calculatePaySlip(paySlipInformation)
          .pipe(take(1))
          .subscribe((response: any) => {
            this.calculatedPaySlip = response.data;
            this.isShowPaySlip = true;
            this.paySlipFormGroup.reset();
        });

    } catch(error: any){
      alert(error);
    }
  }

  reset(){
    this.paySlipFormGroup.reset();
    this.isShowPaySlip = false;
  }
}

