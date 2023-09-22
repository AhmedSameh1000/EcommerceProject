import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartItemComponent } from './cart-item/cart-item.component';
import { SummaryComponent } from './summary/summary.component';
import { FailurePaymentPageComponent } from './failure-payment-page/failure-payment-page.component';
import { SuccessPaymentPageComponent } from './success-payment-page/success-payment-page.component';

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
  },
  {
    path:"Summary",
    component:SummaryComponent
  },
  {
    path:"successPaymentPage",
    component:SuccessPaymentPageComponent
  },
  {
    path:"failurePaymentPage",
    component:FailurePaymentPageComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShopRoutingModule { }
