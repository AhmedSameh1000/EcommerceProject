import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private Http:HttpClient) { }


  LogIn(LogInForm:any){
    return this.Http.post(environment.baseUrl+"Auth/LogIN",LogInForm)
  }

  Register(RegisterForm:any){
    return this.Http.post(environment.baseUrl+"Auth/Register",RegisterForm)
  }
  IsLogIn(){
    if(localStorage.getItem('token'))
    return true;

    return false;
  }
  LogOut(){
    localStorage.removeItem("token")
  }

}
