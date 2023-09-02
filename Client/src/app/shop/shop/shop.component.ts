import { Component, OnInit } from '@angular/core';
import { ShopService } from '../Services/shop.service';
import { Pagination } from 'src/app/shared/Models/Paging';
import { Product } from 'src/app/shared/Models/Product';
import { Brand } from 'src/app/shared/Models/Brand';
import { type } from 'src/app/shared/Models/Type';
import { params } from 'src/app/shared/Models/params';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  constructor(private ShopServic:ShopService){
  }
  Pagination!:Pagination<Product[]>
  Brands:Brand[]=[];
  Types:type[]=[];
  

  ngOnInit(): void {
    this.LoadProduct()
    this.loadBrands()
    this.loadTypes()

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

  loadBrands(){
    this.ShopServic.GetBrands().subscribe({
      next:(res)=>{
        this.Brands=[{id:0,name:"All"},...res]       
      }
    })
  }
  loadTypes(){
    this.ShopServic.GetTypes().subscribe({
      next:(res)=>{
        this.Types=[{id:0,name:"All"},...res];
      }
    })
  }
  OnBrandSelected(brandId:number){
    this.AllParams.brandIdSelected=brandId;
    this.LoadProduct();
  }
  OnTypeSelected(TypeId:number){
    this.AllParams.TypeIdSelected=TypeId;
    this.LoadProduct();
    
  }
  OnSearch(inpt:HTMLInputElement){
    if(inpt.value=="" )
    return;
    this.AllParams.SearchInput=inpt.value;
    this.LoadProduct()
  }
  change(event:any){
    this.AllParams.page=event.page;
    this.LoadProduct()
  }
}
