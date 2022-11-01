import { Injectable } from '@angular/core';
import { Actions, createEffect, Effect, ofType } from '@ngrx/effects';
import { Action, Store } from '@ngrx/store';
import { catchError, Observable, of, switchMap } from 'rxjs';
import { PaySlipCalculateService } from 'src/app/service/pay-slip-calculate.service';
import { PaySlipActionType, PaySlipCalculateAction } from '../actions/pay-slip.actions';
import { AppState } from '../app-state';

@Injectable()
export class PaySlipCalculateEffects {
    constructor(
        private actions$: Actions, 
        private store: Store<AppState>,
        private service: PaySlipCalculateService) {

        }
    
    //calculatePaySlip$ = createEffect(() => {
    //  return this.actions$.pipe(
     //   ofType(PaySlipCalculateAction),
       //     switchMap((action) => {
         //       return this.service.calculatePaySlip(action.)
           // })
        //)
    //});

        
}

