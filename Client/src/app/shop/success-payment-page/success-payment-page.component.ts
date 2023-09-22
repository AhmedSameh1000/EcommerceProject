import { Component, OnInit } from '@angular/core';
import { ShopService } from '../Services/shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-success-payment-page',
  templateUrl: './success-payment-page.component.html',
  styleUrls: ['./success-payment-page.component.css']
})
export class SuccessPaymentPageComponent implements OnInit {
constructor(private ShopServices:ShopService,private route: ActivatedRoute){

}

id:any
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.id = params['id'];
      // Use the parameter value as needed
    });


    this.ShopServices.OrderConfirmation(+this.id).subscribe({
      next:(res)=>{
     console.log(res) 
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

}
