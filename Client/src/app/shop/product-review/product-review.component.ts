import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ShopService } from '../Services/shop.service';

@Component({
  selector: 'app-product-review',
  templateUrl: './product-review.component.html',
  styleUrls: ['./product-review.component.css']
})
export class ProductReviewComponent implements OnInit {
constructor(private MatdialogRef:MatDialogRef<ProductReviewComponent>,
  @Inject(MAT_DIALOG_DATA) public data: {id: string},
  private ShopService:ShopService){

}
  ngOnInit(): void {
  this.GetReviews()
  }

Reviews:any
GetReviews(){

  this.ShopService.GetReviews(this.data).subscribe({
    next:(res)=>{
      this.Reviews=res
      console.log(res)
    },
    error:(err)=>{
      console.log(err)
    }
  })
}

  Close(){

    this.MatdialogRef.close(false)
  }
}
