import { Injectable, EventEmitter } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class DataService {

  private messageSource = new BehaviorSubject('default message');
  currentMessage = this.messageSource.asObservable();

  searchBoxValue: string = '';
  searchBoxValueChange: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  onSearchBoxValueChange(value: string){
    this.searchBoxValue = value;
    //console.log(this.searchBoxValue);
    this.searchBoxValueChange.emit(this.searchBoxValue);
  }
  changeMessage(message: string) {
    this.messageSource.next(message)
  }

}