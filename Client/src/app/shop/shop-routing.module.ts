import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartItemComponent } from './cart-item/cart-item.component';

const routes: Routes = [
  {
    path:"Products",
    component:ShopComponent
  },
  {
    path:"Products/:id",
    component:ProductDetailsComponent
  },
  {
    path:"CartItem",
    component:CartItemComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShopRoutingModule { }
