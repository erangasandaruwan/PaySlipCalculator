import { Action, createAction, props } from '@ngrx/store';
import { CalculatedPaySlip } from 'src/app/model/calculated-pay-slip';
import { PaySlipInformation } from 'src/app/model/pay-slip-info';

export enum PaySlipActionType {
    CALCULATE = '[PaySlip] Calculate Pay',
    CALCULATE_SUCCESSFULL = '[PaySlip] Calculated Pay Successfully',
    CALCULATE_FAILED = '[PaySlip] Calculated Pay Not Successfull'
  }
  
  export class PaySlipCalculateAction implements Action {
    readonly type = PaySlipActionType.CALCULATE;
  
    constructor(public payload: PaySlipInformation) {}
  }

  export class PaySlipCalculateSuccessAction implements Action {
    readonly type = PaySlipActionType.CALCULATE_SUCCESSFULL;
  
    constructor(public payload: CalculatedPaySlip) {}
  }
  
  export class PaySlipCalculateFailAction implements Action {
    readonly type = PaySlipActionType.CALCULATE_FAILED;
  
    constructor(public payload: PaySlipInformation) {}
  }
  
  export type PaySlipAction = 
      PaySlipCalculateAction | PaySlipCalculateSuccessAction | PaySlipCalculateFailAction;