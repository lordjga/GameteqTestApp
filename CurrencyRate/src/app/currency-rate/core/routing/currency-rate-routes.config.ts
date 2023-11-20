import { Routes } from "@angular/router";
import { CurrencyRateComponent } from "../../currency-rate.component";

export const CURRENCY_RATE_ROUTES: Routes = [
  {
    path: '',
    component: CurrencyRateComponent,
    children: [
      {
        path: '', redirectTo: 'home', pathMatch: 'full'
      },
      {
        path: 'home',
        loadChildren: () => import('../../home/home.module').then(m => m.HomeModule),
      }
    ]
  }
]
