import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ShopService } from 'src/app/shop/Services/shop.service';
import { CreateBrandComponent } from '../create-brand/create-brand.component';
import Swal from 'sweetalert2'
@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent implements OnInit {
    constructor(private shopService:ShopService,
      private MatDilog:MatDialog){    
    }
  ngOnInit(): void {
    this.LoadBrands()
  }
    Brands:any;
    LoadBrands(){
      this.shopService.GetBrands().subscribe({
        next:(res)=>{
          this.Brands=res
        }
      })
    }
    OpenDialog(){

     var Dialogref= this.MatDilog.open(CreateBrandComponent,{
          width:"700px"
        })

        Dialogref.afterClosed().subscribe({
          next:(res)=>{
            this.Brands.push(res)
          }
        })
      }
      
  Delete(id:number,Div:HTMLElement){
    Swal.fire({
      title: 'Are you sure?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      text:'Be Careful All Propduct in this Brand Will Removed AFter Deleted',
      cancelButtonColor: '#3085d6',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) 
      {
     this.shopService.DeleteBrand(id).subscribe
     ({
          next:(res)=>{
            Div.remove()
            Swal.fire(
              'Deleted!',
              'Brand has been deleted.',
              'success'
            )
      }
     })
      }
    })
  }
}
