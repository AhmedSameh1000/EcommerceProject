import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { CarouselModule } from 'ngx-bootstrap/carousel';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import {MatCardModule} from '@angular/material/card';

let _shardModulese=[

  PaginationModule.forRoot(),
  ToastrModule.forRoot({
    closeButton:true,
    progressBar:true,
    positionClass: 'toast-bottom-right',
  }), 
  NgxSpinnerModule.forRoot({ type: 'square-jelly-box' }),
  CarouselModule.forRoot(),
  MatDialogModule,
  MatSelectModule,
  MatFormFieldModule,
  BsDropdownModule.forRoot(),
  MatCardModule
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
