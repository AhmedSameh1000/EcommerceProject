import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ShopService } from '../Services/shop.service';
import { AuthService } from 'src/app/auth/Auth/auth.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent {
  constructor(private MatDialogref:MatDialogRef<ReviewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {id: string},
    private ShopService:ShopService,private AuthService:AuthService){

  }
  AddReview(comment:HTMLTextAreaElement){
    var review={
      userName:this.AuthService.GetUserName(),
      userId:this.AuthService.GetLoggedInUserId(),
      productId:+this.data,
      reviewText:comment.value,
      reviewStarts:+this.startCount
    }
    this.ShopService.AddReview(review).subscribe({
      next:(res)=>{
        console.log(res)
        this.MatDialogref.close(true)
      },
      error:(err)=>{
        console.log(err)
      }
    })
   console.log(review)
  }
  startCount = 1;
  Close(){
    this.MatDialogref.close(false)
  }

}
