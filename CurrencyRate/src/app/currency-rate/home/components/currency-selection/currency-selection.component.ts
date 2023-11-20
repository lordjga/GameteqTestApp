import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Currency } from '../../../shared/models/currency.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CurrencyRate } from '../../../shared/models/currency-rate.model';
import { CurrencySelect } from '../../../shared/models/currency-select.model';



@Component({
  selector: 'app-currency-selection',
  templateUrl: './currency-selection.component.html',
  styleUrls: ['./currency-selection.component.css']
})
export class CurrencySelectionComponent {
  @Input() Currencies: Array<Currency> | null = [];

  @Output() dataSelected: EventEmitter<any> = new EventEmitter<any>();

  currencyDate = new FormControl(new Date(), [Validators.required]);
  minDate: Date;
  maxDate: Date;

  currencyRate: CurrencySelect | undefined;

  public currencyFormGroup = new FormGroup({
    currencyId: new FormControl(0, [Validators.required]),
    currencyDate: this.currencyDate,
  })

  constructor() {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(1991, 0, 1);
    this.maxDate = new Date(currentYear, 11, 31);
  }

  sendForm(): void {    
    if (!this.currencyFormGroup.invalid) {
      this.currencyRate = {
        currencyId: this.currencyFormGroup.value.currencyId as number,
        date: this.currencyFormGroup.value.currencyDate as Date 
      };

      this.dataSelected.emit(this.currencyRate);
    }
    else {
      this.validateForm();
    }
  }

  validateForm() {
    if (this.currencyFormGroup.invalid) {
      this.currencyFormGroup.markAllAsTouched();
      return;
    }
  }
}
