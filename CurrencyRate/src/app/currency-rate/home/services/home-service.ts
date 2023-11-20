import { Injectable } from "@angular/core";
import { HomeApiService } from "./home-api.service";
import { Currency } from "../../shared/models/currency.model";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class HomeService {
  private currencies$: BehaviorSubject<Currency[]> = new BehaviorSubject([] as Currency[]);
  private currencies: Array<Currency> = [];

  public isDataLoaded = false;

  constructor(private homeApiService: HomeApiService) {
  }

  public getAllCurrenciesFromServer() {
    this.homeApiService.getAllCurrencies().subscribe(res => {
      this.currencies = res;
      this.currencies$.next(this.currencies);
      this.isDataLoaded = true;
    });
  }

  get getUserData$(): Observable<Currency[]> {
    return this.currencies$.asObservable();
  }
}
