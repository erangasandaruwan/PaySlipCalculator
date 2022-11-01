import { CalculatedPaySlip } from "src/app/model/calculated-pay-slip";
import { PaySlipAction, PaySlipActionType } from "../actions/pay-slip.actions";

const initialState: Array<CalculatedPaySlip> = [];

export function PaySLipCalculateReducer(
    state: Array<CalculatedPaySlip> = initialState ,
    action: PaySlipAction
  ) {
    switch (action.type) {
      case PaySlipActionType.CALCULATE:
        return [...state, action.payload];
      default:
        return state;
    }
  }