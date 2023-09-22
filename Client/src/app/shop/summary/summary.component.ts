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

  ngOnInit(): void {
   this.GetOrder()
 this.currentDateTime.setDate(this.currentDateTime.getDate() + 7);

  }

  StartPay(){    
    this.shopService.StartPay(this.authServic.GetLoggedInUserId()).subscribe({
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
   console.log(res)
      }
    })
  }

}
