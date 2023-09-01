import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/Models/Product';
import { ShopService } from 'src/app/shop/Services/shop.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    constructor(private ShopService:ShopService){

    }
    ProductsImages!:Product[]
  ngOnInit(): void {
   this.ShopService.GetProductsImages().subscribe({
    next:(res)=>{
      this.ProductsImages=res
    }
   })
  }
}
