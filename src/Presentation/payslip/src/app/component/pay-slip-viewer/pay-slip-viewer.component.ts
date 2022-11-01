import { animate, state, style, transition, trigger } from '@angular/animations';
import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CalculatedPaySlip } from 'src/app/model/calculated-pay-slip';
import { AppState } from 'src/app/state/app-state';

@Component({
  selector: 'app-pay-slip-viewer',
  templateUrl: './pay-slip-viewer.component.html',
  styleUrls: ['./pay-slip-viewer.component.css']
})
export class PaySlipViewerComponent implements OnInit {  
  @Input() isVisible: boolean | undefined;
  @Input() paySlip: CalculatedPaySlip | any;

  constructor() { }

  ngOnInit(): void { }

  ngOnChanges() {
  }

  printPaySlip() {
    var printContents = window.document.getElementById('paySlipCard')?.innerHTML;
    let document: Document | any = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto')?.document.open();
    document.write(`
      <html>
        <head>
          <title>Print tab</title>
        </head>
        <body onload="window.print();window.close()">${printContents}</body>
      </html>`);
    document.close();
  }
}
