import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ShopService } from 'src/app/shop/Services/shop.service';
import { CreateTypeComponent } from '../create-type/create-type.component';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-type-list',
  templateUrl: './type-list.component.html',
  styleUrls: ['./type-list.component.css']
})
export class TypeListComponent {
  constructor(private shopService:ShopService,
    private MatDilog:MatDialog){    
  }
ngOnInit(): void {
  this.LoadTypes()
}
  Types:any;
  LoadTypes(){
    this.shopService.GetTypes().subscribe({
      next:(res)=>{
        this.Types=res
      }
    })
  }
  OpenDialog(){

   var Dialogref= this.MatDilog.open(CreateTypeComponent,{
        width:"700px"
      })

      Dialogref.afterClosed().subscribe({
        next:(res)=>{
          if(res != null){
            this.Types.push(res)
          }
        }
      })
    }
    
Delete(id:number,Div:HTMLElement){
  Swal.fire({
    title: 'Are you sure?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#d33',
    text:'Be Careful All Propduct in this Type Will Removed AFter Deleted',
    cancelButtonColor: '#3085d6',
    confirmButtonText: 'Yes, delete it!'
  }).then((result) => {
    if (result.isConfirmed) 
    {
   this.shopService.DeleteType(id).subscribe
   ({
        next:(res)=>{
          Div.remove()
          Swal.fire(
            'Deleted!',
            'Type has been deleted.',
            'success'
          )
    }
   })
    }
  })
}
}
