import { Component } from '@angular/core';
import { HomeService } from './services/home-service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Currency } from '../shared/models/currency.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(
    private homeService: HomeService) { }

  ngOnInit(): void {
    if (!this.homeService.isDataLoaded)
      this.homeService.getAllCurrenciesFromServer();
  }

  get getUserData$(): Observable<Currency[]> {
    return this.homeService.getUserData$;
  }

}
