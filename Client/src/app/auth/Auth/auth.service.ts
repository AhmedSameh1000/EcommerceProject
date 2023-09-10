import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Token } from '@angular/compiler';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  JWTHealper = new JwtHelperService();
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

  GetToken(){
    if(!this.IsLogIn()){
      return
    }
    var token=localStorage.getItem("token");
    return token;
  }
  LogOut(){
    localStorage.removeItem("token")
  }

  isAdmin(){
    if(!this.IsLogIn())
    return;
    var token=this.GetToken();
    var TokeneData=this.JWTHealper.decodeToken(token!).roles as string[];
  console.log(TokeneData)
  
    if(TokeneData.includes('Admin')){
      return true
    }
    else  {
      return false;
    }
  }

  isModerator(){
    if(!this.IsLogIn())
    return;
    var token=this.GetToken();
    var TokeneData=this.JWTHealper.decodeToken(token!).roles as string[];
    if(TokeneData.includes('Moderator')){
      return true
    }
    else  {
      return false;
    }
  }

}
