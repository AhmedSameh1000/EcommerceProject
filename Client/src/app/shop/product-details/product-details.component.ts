import { Component, OnInit } from '@angular/core';
import { ShopService } from '../Services/shop.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/shared/Models/Product';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { CartItem } from 'src/app/shared/Models/CartItem';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/auth/Auth/auth.service';
import { CartItemService } from 'src/app/shared/Services/cart-item.service';
import { MatDialog } from '@angular/material/dialog';
import { ReviewComponent } from '../review/review.component';
import { ProductReviewComponent } from '../product-review/product-review.component';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
constructor(private shopService:ShopService,
  private Route:ActivatedRoute,private Toaster:ToastrService,
  private spinner: NgxSpinnerService,
  private AuthService:AuthService,
  private CartItemService:CartItemService,
  private MatDialog:MatDialog){

}

CartItem!:CartItem;
  ngOnInit(): void {
    this.spinner.show()
   this.LoadProduct()
  }

  LoadProduct(){
    const id=this.Route.snapshot.paramMap.get('id');
    if(id == null)
    return;
    this.shopService.GetProduct(+id).subscribe({
      next:(res)=>{
        this.CartItem=res
        console.log(res)
        this.spinner.show();
      
      },
      error:(e)=>console.log(e),
      complete:()=>{
        this.spinner.hide()
      }
    })
  }
 
  SaveCartItem(inp:any){
    const id=parseInt(this.Route.snapshot.paramMap.get('id')!);
    var cartItemDTO={
       productId:id,
       count:+inp.textContent,
       UserId:this.AuthService.GetLoggedInUserId()
    }
    this.CartItemService.SendCartItem(cartItemDTO).subscribe({ 
      next:(res)=>{
        console.log(res)
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }
  OpenReviewComponent(){
    const id=this.Route.snapshot.paramMap.get('id');
 var DialogRef= this.MatDialog.open(ReviewComponent,{
   width:"400px",
   disableClose:true,
   maxHeight:"500px",
   data:id
  })
  DialogRef.afterClosed().subscribe(res=>{
    if(res){
      this.LoadProduct()
    }
  })
  }

  OpenReviewsForProduct(){
    const id=this.Route.snapshot.paramMap.get('id');
    this.MatDialog.open(ProductReviewComponent,{
      width:"400px",
      maxHeight:"500px",
      data:id,
      disableClose:true
    })
  }
  increesCartitemCount(inp:any){

    inp.textContent++;
  }
  DecreesCartitemCount(inp:any){
    if(inp.textContent<=1){
      return
    }
    inp.textContent--;
  }
}
