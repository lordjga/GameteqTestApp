import { NgModule } from '@angular/core';
import { CommonModule, DatePipe, NgFor } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule } from '@angular/router';
import { HOME_ROUTES } from './routing/home-routes.config';
import { CurrencySelectionComponent } from './components/currency-selection/currency-selection.component';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    HomeComponent,
    CurrencySelectionComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    NgFor,

    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,

    RouterModule.forChild(HOME_ROUTES)
  ],
  providers: [
    DatePipe
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
