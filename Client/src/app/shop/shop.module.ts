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
import { SummaryComponent } from './summary/summary.component';
import { SuccessPaymentPageComponent } from './success-payment-page/success-payment-page.component';
import { FailurePaymentPageComponent } from './failure-payment-page/failure-payment-page.component';
import { OrdersComponent } from './orders/orders.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { MyOrdersComponent } from './my-orders/my-orders.component';
import { ReviewComponent } from './review/review.component';
import { ProductReviewComponent } from './product-review/product-review.component';


@NgModule({
  declarations: [
    ShopComponent,
    ProductDetailsComponent,
    CartItemComponent,
    SummaryComponent,
    SuccessPaymentPageComponent,
    FailurePaymentPageComponent,
    OrdersComponent,
    UserOrdersComponent,
    MyOrdersComponent,
    ReviewComponent,
    ProductReviewComponent
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
