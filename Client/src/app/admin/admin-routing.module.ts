import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsListComponent } from './products-list/products-list.component';
import { BrandListComponent } from './brand-list/brand-list.component';

const routes: Routes = [
  {
    path:'ProductsList',
    component:ProductsListComponent
  },
  {
    path:'BrandsList',
    component:BrandListComponent
  },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
