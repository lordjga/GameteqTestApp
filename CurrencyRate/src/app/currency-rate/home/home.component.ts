import { Component } from '@angular/core';
import { HomeService } from './services/home-service';
import { Observable } from 'rxjs';
import { Currency } from '../shared/models/currency.model';
import { CurrencySelect } from '../shared/models/currency-select.model';
import { CurrencyRate } from '../shared/models/currency-rate.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  currencyRate: CurrencyRate | undefined;

  constructor(
    private homeService: HomeService) { }

  ngOnInit(): void {
    if (!this.homeService.isDataLoaded)
      this.homeService.loadAllCurrenciesFromServer();
  }

  get getCurrencyData$(): Observable<Currency[]> {
    return this.homeService.getCurrencyData$;
  }

  getRate(item: CurrencySelect) {
    this.homeService.loadRate(item).subscribe(res => {
      this.currencyRate = res;
    });;
  }
}
