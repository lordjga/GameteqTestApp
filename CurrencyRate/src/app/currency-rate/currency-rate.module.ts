import { CommonModule, NgFor } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CurrencyRateComponent } from './currency-rate.component';
import { HeaderComponent } from './header/header.component';
import { HomeModule } from './home/home.module';
import { MatToolbarModule } from '@angular/material/toolbar';


@NgModule({
  declarations: [
    CurrencyRateComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    RouterModule,

    HomeModule,

    MatToolbarModule,

  ],
  exports: [
    CurrencyRateComponent
  ]
})
export class CurrencyRateModule { }
