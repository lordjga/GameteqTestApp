import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CURRENCY_RATE_ROUTES } from './currency-rate-routes.config';

@NgModule({
  imports: [RouterModule.forRoot(CURRENCY_RATE_ROUTES)],
  exports: [RouterModule]
})

export class CurrencyRateRoutingModule { }
