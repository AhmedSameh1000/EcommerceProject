import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { CarouselModule } from 'ngx-bootstrap/carousel';
import {MatDialogModule} from '@angular/material/dialog';

let _shardModulese=[
  PaginationModule.forRoot(),
  ToastrModule.forRoot({
    closeButton:true,
    progressBar:true,
    positionClass: 'toast-bottom-right',
  }), 
  NgxSpinnerModule.forRoot({ type: 'square-jelly-box' }),
  CarouselModule.forRoot(),
  MatDialogModule
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedRoutingModule,
    _shardModulese,
    
  ],
  exports:[_shardModulese]

})
export class SharedModule { }
