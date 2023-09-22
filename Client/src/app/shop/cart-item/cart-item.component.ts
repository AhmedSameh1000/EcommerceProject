import { Component, OnInit } from '@angular/core';
import { ShopService } from '../Services/shop.service';
import { AuthService } from 'src/app/auth/Auth/auth.service';
import Swal from 'sweetalert2'
@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
    constructor(private shopService:ShopService,
      private AuthService:AuthService){
      
    }
  ngOnInit(): void {
   this.GetCartItems()
  }

 

  Increment(id:any){
    this.shopService.IncrementCartItem(id).subscribe({
      next:(res)=>{

      }
      ,complete:()=>{
        this.GetCartItems()
      }
    })
  }
  Decrement(id:any){
    this.shopService.DecrementCartItem(id).subscribe({
      next:(res)=>{

      }
      ,complete:()=>{
        this.GetCartItems()
      }
    })
  }

  Remove(id:any){
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
     this.shopService.RemoveCartItem(id).subscribe
     ({
          next:(res)=>{},
          complete:()=>
          {
            Swal.fire(
              'Deleted!',
              'Cart Item has been deleted.',
              'success'
            )
            this.GetCartItems()
          }
     })
      }
    })
  }

    CartItems:any

    GetCartItems(){

      this.shopService.GetCartItems(this.AuthService.GetLoggedInUserId())
      .subscribe({
        next:(res:any)=>{
          this.CartItems=res
          console.log(res)
        },
        error:(err)=>{
        }
      })
    }
}
