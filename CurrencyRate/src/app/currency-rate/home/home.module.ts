import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule } from '@angular/router';
import { HOME_ROUTES } from './routing/home-routes.config';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,

    RouterModule.forChild(HOME_ROUTES)
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
