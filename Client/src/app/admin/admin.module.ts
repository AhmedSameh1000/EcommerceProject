import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { ProductsListComponent } from './products-list/products-list.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { CreateProductComponent } from './create-product/create-product.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrandListComponent } from './brand-list/brand-list.component';
import { CreateBrandComponent } from './create-brand/create-brand.component';


@NgModule({
  declarations: [
    ProductsListComponent,
    CreateProductComponent,
    BrandListComponent,
    CreateBrandComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    RouterModule,
    SharedModule    ,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[CreateProductComponent]
})
export class AdminModule { }
