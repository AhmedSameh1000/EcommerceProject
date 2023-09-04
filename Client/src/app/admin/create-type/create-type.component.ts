import { Component } from '@angular/core';
import { ShopService } from 'src/app/shop/Services/shop.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-type',
  templateUrl: './create-type.component.html',
  styleUrls: ['./create-type.component.css']
})
export class CreateTypeComponent {
  constructor(private ShopService:ShopService,
    private matDialogRef:MatDialogRef<CreateTypeComponent>,
    private Toster:ToastrService){
    
  }


Close(){
  this.matDialogRef.close();
}
Create(inp:HTMLInputElement){
  if(inp.value==""){
    return;
  }  

  var Type={
    name:inp.value
  }
  this.ShopService.CreateType(Type).subscribe({
    next:(res)=>{
      this.matDialogRef.close(res)
    },
    error:(err)=>{
      console.log(err)
    },
    complete:()=>{
      this.Toster.success("Type Create Succefuly")
    }
  })
  
}
}
