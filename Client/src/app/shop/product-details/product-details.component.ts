import { Component, OnInit } from '@angular/core';
import { ShopService } from '../Services/shop.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/shared/Models/Product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
constructor(private shopService:ShopService,private Route:ActivatedRoute){

}
Product!:Product;
  ngOnInit(): void {
   this.LoadProduct()
  }
  LoadProduct(){
    const id=this.Route.snapshot.paramMap.get('id');
    if(id == null)
    return;
    this.shopService.GetProduct(+id).subscribe({
      next:(res)=>{
        this.Product=res
        console.log(res)
      },
      error:(e)=>console.log(e)
    })
  }
}
