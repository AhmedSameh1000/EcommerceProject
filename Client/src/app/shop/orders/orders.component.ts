import { Component, OnInit } from '@angular/core';
import { ShopService } from '../Services/shop.service';
import { MatDialog } from '@angular/material/dialog';
import { UserOrdersComponent } from '../user-orders/user-orders.component';
import { AuthService } from 'src/app/auth/Auth/auth.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  constructor (private shopService:ShopService,
    private MatDialog:MatDialog,public authservice:AuthService){
      this.Status=["All","Pending","Processing","Completed"]
  }

  Status:any[];
  StatSelected="All"
  ngOnInit(): void {
   this.LoadPackages()
  }


  LoadPackages(){
    this.shopService.GetPackges().subscribe({
      next:(res)=>{
        this.Orders=res
        console.log(res)
      }
    })
  }

  Orders:any
  OpenDialog(userId:any){
  var Dialog=  this.MatDialog.open(UserOrdersComponent,{
      data:userId,
      disableClose:true,
     
    })
    Dialog.afterClosed().subscribe(res=>{
      if(res){
        this.LoadPackages()
      }
    })
  }

  GetOrdersWithStatus(current:HTMLAnchorElement,list:HTMLLIElement){

    for (let i = 0; i < list.children.length; i++) {   
      list.children[i].classList.remove("active")
    }
    current.classList.add("active")
  }
}
