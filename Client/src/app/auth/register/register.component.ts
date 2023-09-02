import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  constructor(private AuthService:AuthService,
    private FormBuilder:FormBuilder,
    private Toaster:ToastrService,
    private Router:Router){

  }
  ngOnInit(): void {
   this.InitializeFormData()
  }
  RegisterFormData!:FormGroup
  InitializeFormData(){
    this.RegisterFormData=this.FormBuilder.group({
      FirstName:['' ,[Validators.required]],
      LastName:['' ,[Validators.required]],
      email:['',[Validators.required,Validators.email]],
      password:['',[Validators.required,Validators.minLength(5)]],
      Confirmpassword:['',[Validators.required,Validators.minLength(5)]]
    })
  }
  emailAlreadyRegister!:string
  Register(){
    if(this.RegisterFormData.invalid){
      return;
    }
    this.AuthService.Register(this.RegisterFormData.value).subscribe({
      next:(res:any)=>{
        localStorage.setItem("token",res.token);
      },
      complete: () => {
        this.Toaster.success("User Register in Succefuly");
        this.Router.navigate(["/Products"]);
      },error:(eror)=>{
        this.Toaster.error(eror.error)
       this.emailAlreadyRegister=eror.error

      }
  
    })
  }

  submited = false;
  Onsubmit() 
  {
    this.submited = true;
    if (this.RegisterFormData.invalid) {
      return;
  }
}
}
