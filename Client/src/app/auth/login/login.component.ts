import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
    constructor(private Authservice:AuthService,
      private FormBuilder:FormBuilder,
      private Router: Router,
      private Toaster:ToastrService
      ){

    }
  ngOnInit(): void {
  this.InitializeFormData();
  }
    LogInForm!:FormGroup

    InitializeFormData(){
      this.LogInForm=this.FormBuilder.group({
        email:['',[Validators.required,Validators.email]],
        password:['',[Validators.required,Validators.minLength(5)]]
      })
    }

    LogIn()
    {
      if(this.LogInForm.invalid){
        return;
      }
      this.Authservice.LogIn(this.LogInForm.value).subscribe({
        next:(res:any)=>{
      localStorage.setItem("token",res.token);
        },
        complete: () => {
          this.Toaster.success("User log in Succefuly");
          this.Router.navigate(["/Products"]);
        },error:(eror)=>{
          this.Toaster.error(eror.error)
        }
      })
     
    }

    submited = false;
    Onsubmit() 
    {
      this.submited = true;
      if (this.LogInForm.invalid) {
        return;
    }
  }
}
