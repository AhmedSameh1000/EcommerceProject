import { Component, ElementRef, OnInit, ViewChild, createComponent } from '@angular/core';
import Swal from 'sweetalert2'

import { Pagination } from 'src/app/shared/Models/Paging';
import { Product } from 'src/app/shared/Models/Product';
import { params } from 'src/app/shared/Models/params';
import { ShopService } from 'src/app/shop/Services/shop.service';
import {MatDialog, MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import { CreateProductComponent } from '../create-product/create-product.component';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  Pagination!:Pagination<Product[]>
  constructor(private ShopServic:ShopService,
    private matDialog:MatDialog){
  }
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
  OpenDialog(){
  let dialogref= this.matDialog.open(CreateProductComponent,{
      width:"700px",
    })

    dialogref.afterClosed().subscribe(result=>{
      if(result){
        this.LoadProduct()
      }
    })
  }
  change(event:any){
    this.AllParams.page=event.page;
    this.LoadProduct()
  }

  delete(id:number,Div:HTMLElement){
    Swal.fire({
      title: 'Are you sure?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) 
      {
     this.ShopServic.DeleteProduct(id).subscribe
     ({
          next:(res)=>{
            Div.remove()
            Swal.fire(
              'Deleted!',
              'Your file has been deleted.',
              'success'
            )
      }
     })
      }
    })
  }
}

