import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsListComponent } from './products-list/products-list.component';
import { BrandListComponent } from './brand-list/brand-list.component';
import { TypeListComponent } from './type-list/type-list.component';

const routes: Routes = [
  {
    path:'ProductsList',
    component:ProductsListComponent
  },
  {
    path:'BrandsList',
    component:BrandListComponent
  },
  {
    path:'TypesList',
    component:TypeListComponent
  },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
