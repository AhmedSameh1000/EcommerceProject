import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { PaginationModule } from 'ngx-bootstrap/pagination';

let _shardModulese=[
  PaginationModule.forRoot()
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedRoutingModule,
    _shardModulese
  ],
  exports:[_shardModulese]

})
export class SharedModule { }
