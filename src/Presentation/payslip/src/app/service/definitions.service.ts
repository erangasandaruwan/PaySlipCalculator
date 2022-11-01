import { Injectable } from '@angular/core';
import { mergeMap, Observable, of } from 'rxjs';
import { KeyValuePair } from '../model/key-value-pair';

@Injectable({
  providedIn: 'root'
})
export class DefinitionsService {

  monthDefinitions: KeyValuePair[] = [];
  constructor() { }

  getMonthsDefinitions() : Observable<KeyValuePair[]> {

    // TO-DO - Read from the back-end and store with state store
    this.monthDefinitions?.push(new KeyValuePair("January","January"));
    this.monthDefinitions?.push(new KeyValuePair("February","February"));
    this.monthDefinitions?.push(new KeyValuePair("March","March"));
    this.monthDefinitions?.push(new KeyValuePair("April","April"));
    this.monthDefinitions?.push(new KeyValuePair("May","May"));
    this.monthDefinitions?.push(new KeyValuePair("June","June"));
    this.monthDefinitions?.push(new KeyValuePair("July","July"));
    this.monthDefinitions?.push(new KeyValuePair("August","August"));
    this.monthDefinitions?.push(new KeyValuePair("September","September"));
    this.monthDefinitions?.push(new KeyValuePair("October","October"));
    this.monthDefinitions?.push(new KeyValuePair("November","November"));
    this.monthDefinitions?.push(new KeyValuePair("December","December"));
    return of(this.monthDefinitions).pipe()
  }
}
