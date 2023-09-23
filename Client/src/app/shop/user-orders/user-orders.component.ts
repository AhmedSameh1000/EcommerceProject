import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ShopService } from '../Services/shop.service';
import { UserService } from 'src/app/admin/UserService/user.service';
import { AuthService } from 'src/app/auth/Auth/auth.service';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit{

  constructor(private MatdialogRef:MatDialogRef<UserOrdersComponent>,
    private ShopService:ShopService,
    @Inject(MAT_DIALOG_DATA) public data: {userId: string},
    private Authservice:AuthService){

  }
  ngOnInit(): void {
    this.LoadPackages()

  }
  Close(){
    this.MatdialogRef.close(false);
  }
  Orders:any
  isDisabled:boolean=false
  LoadPackages(){
    this.ShopService.GetUSerPackagesById(this.data).subscribe({
      next:(res:any)=>{
        this.Orders=res
        this.Status=res
      this.isDisabled= res[0].reciverId==this.Authservice.GetLoggedInUserId()?false:true     
      }
    })
  }
  Status:any
  StartProcessing(){
    this.ShopService.startProcessing(this.data,this.Authservice.GetLoggedInUserId()).subscribe({
      next:(res)=>{
        console.log(res)
      },
      complete:()=>{
        this.MatdialogRef.close(true)
      }
    })
  }

  CompleteTask(){
    this.ShopService.CompleteProcessing(this.data,this.Authservice.GetLoggedInUserId()).subscribe({
      next:(res)=>{
        console.log(res)
      },
      complete:()=>{
        this.MatdialogRef.close(true)
      }
    })
  }

}
