import { Component, OnInit } from '@angular/core';
import { ShopService } from '../Services/shop.service';
import { AuthService } from 'src/app/auth/Auth/auth.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit{
 constructor(private shopService:ShopService,
  private authServic:AuthService){

 }
  currentDateTime = new Date();

  Address:any="";
  City:any="";
  PhoneNumber:any="";
  Name:any=""

  ngOnInit(): void {
   this.GetOrder()
 this.currentDateTime.setDate(this.currentDateTime.getDate() + 7);

  }

  StartPay(){
    
    var userData={
      name:this.Name,
      address:this.Address,
      city:this.City,
      Phone:this.PhoneNumber
    }
    if(userData.name==""||
    userData.address==""||
    userData.city==""
    ||userData.Phone==""){
      return;
    }

    
    this.shopService.StartPay(this.authServic.GetLoggedInUserId(),userData).subscribe({
      next:(res:any)=>{ 
       location.href=res.url
      
      }
    })
  }




  OrderSummary:any
  GetOrder(){
    this.shopService.summaryGet(this.authServic.GetLoggedInUserId())
    .subscribe({
      next:(res:any)=>{
   this.OrderSummary=res
   this.Name=res.orderHeader.name
   this.Address=res.orderHeader.city
   this.City=res.orderHeader.city
   this.PhoneNumber=res.orderHeader.phoneNumber
   console.log(res)
      }
    })
  }

}
