import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ShopService } from 'src/app/shop/Services/shop.service';

@Component({
  selector: 'app-create-brand',
  templateUrl: './create-brand.component.html',
  styleUrls: ['./create-brand.component.css']
})
export class CreateBrandComponent {
    constructor(private ShopService:ShopService,
      private matDialogRef:MatDialogRef<CreateBrandComponent>,
      private Toster:ToastrService){
      
    }


  Close(){
    console.log("ahmed")
    this.matDialogRef.close();
  }
  Create(inp:HTMLInputElement){
    if(inp.value==""){
      return;
    }  

    var Brand={
      name:inp.value
    }
    this.ShopService.CreateBrand(Brand).subscribe({
      next:(res)=>{
        console.log(res)
        this.matDialogRef.close(res)
      },
      error:(err)=>{
        console.log(err)
      },
      complete:()=>{
        this.Toster.success("Brand Create Succefuly")
      }
    })
    
  }
}
