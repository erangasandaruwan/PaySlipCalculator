import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PaySlipInformation } from '../model/pay-slip-info';
import { EndPoints, environment } from 'src/environments/environment';
import { CalculatedPaySlip } from '../model/calculated-pay-slip';
import { catchError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaySlipCalculateService {

  getPaySlips() : Observable<CalculatedPaySlip> {
    var url = environment.baseUrl + "api/PaySlip"
    const headers = { 'content-type': 'application/json'}  
    return this.http.get<CalculatedPaySlip>(url,{'headers':headers});
  }

  constructor (private http: HttpClient) {}

  calculatePaySlip(payload:PaySlipInformation) : Observable<CalculatedPaySlip> {
    var url = environment.baseUrl + "api/PaySlip/calculate"
    const headers = { 'content-type': 'application/json'}  
    const body = JSON.stringify(payload);
    return this.http.post<CalculatedPaySlip>(url, body,{'headers':headers});
  }


}
