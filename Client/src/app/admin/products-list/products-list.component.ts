import { Component } from '@angular/core';
import { Pagination } from 'src/app/shared/Models/Paging';
import { Product } from 'src/app/shared/Models/Product';
import { params } from 'src/app/shared/Models/params';
import { ShopService } from 'src/app/shop/Services/shop.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent {
  constructor(private ShopServic:ShopService){
  }
  Pagination!:Pagination<Product[]>

  

  ngOnInit(): void {
    this.LoadProduct()
  }
  AllParams=new params()

  LoadProduct(){
    this.ShopServic.GetProducts(this.AllParams).subscribe({
      next:(res)=>{
        this.Pagination=res;
     
      },
      error:(e)=>console.log(e)
    })

  }

  change(event:any){
    this.AllParams.page=event.page;
    this.LoadProduct()
  }
}
