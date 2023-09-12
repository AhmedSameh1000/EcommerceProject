import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShopRoutingModule } from './shop-routing.module';
import { ShopComponent } from './shop/shop.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';
import { CartItemComponent } from './cart-item/cart-item.component';


@NgModule({
  declarations: [
    ShopComponent,
    ProductDetailsComponent,
    CartItemComponent
  ],
  imports: [
    CommonModule,
    ShopRoutingModule,
    BsDropdownModule.forRoot(),
    SharedModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule
  ],
  exports:[ShopComponent]
})
export class ShopModule { }
