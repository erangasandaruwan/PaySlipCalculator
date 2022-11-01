import { CalculatedPaySlip } from "../model/calculated-pay-slip";

export const CALCULATE_PAYSLIP = "CALCULATE_PAYSLIP";
export const CALCULATE_PAYSLIP_SUCCESS = "CALCULATE_PAYSLIP_SUCCESS";
export const CALCULATE_PAYSLIP_ERROR = "CALCULATE_PAYSLIP_ERROR";

export interface AppState {
    readonly payslips: Array<CalculatedPaySlip>;
}