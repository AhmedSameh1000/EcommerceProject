import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/Auth/auth.service';
import { ShopService } from '../Services/shop.service';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.css']
})
export class MyOrdersComponent implements OnInit {
 constructor(private authservices:AuthService,private shopservices:ShopService){

 }
 
 
  ngOnInit(): void {
  this.loadOrders()
  }

  completedOrders:any
  loadOrders(){

    this.shopservices.GetOrders(this.authservices.GetLoggedInUserId()).subscribe({
      next:(res)=>{
        this.completedOrders=res
        console.log(res)
      }
    })
    
  }

}
