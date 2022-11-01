import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PaySlipCalculateComponent } from './component/pay-slip-calculate/pay-slip-calculate.component';
import { PaySlipViewerComponent } from './component/pay-slip-viewer/pay-slip-viewer.component';

@NgModule({
  declarations: [
    AppComponent,
    PaySlipCalculateComponent,
    PaySlipViewerComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
