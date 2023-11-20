import { Injectable } from "@angular/core";
import { HomeApiService } from "./home-api.service";
import { Currency } from "../../shared/models/currency.model";
import { BehaviorSubject, Observable } from "rxjs";
import { CurrencyRate } from "../../shared/models/currency-rate.model";
import { CurrencySelect } from "../../shared/models/currency-select.model";
import { DatePipe } from "@angular/common";

@Injectable({
  providedIn: 'root'
})

export class HomeService {
  private currencies$: BehaviorSubject<Currency[]> = new BehaviorSubject([] as Currency[]);
  private currencies: Array<Currency> = [];

  public isDataLoaded = false;

  constructor(private homeApiService: HomeApiService, private datepipe: DatePipe) {
  }

  public loadAllCurrenciesFromServer() {
    this.homeApiService.getRequest<Currency[]>("api/currency").subscribe(res => {
      this.currencies = res;
      this.currencies$.next(this.currencies);
      this.isDataLoaded = true;
    });
  }

  get getCurrencyData$(): Observable<Currency[]> {
    return this.currencies$.asObservable();
  }

  public loadRate(item: CurrencySelect): Observable<CurrencyRate> {
    var date = this.datepipe.transform(item.date, 'yyyy-MM-dd');
    return this.homeApiService.getRequest<CurrencyRate>(`api/currency/getRate?currencyId=${item.currencyId}&date=${date}`);
  }
}
