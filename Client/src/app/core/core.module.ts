import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [NavBarComponent],
  imports: [
    CommonModule,
    CoreRoutingModule,
    RouterModule,
    SharedModule
  ],
  exports:[NavBarComponent]
})
export class CoreModule { }
