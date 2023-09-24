import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth/Auth/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private AuthServices:AuthService) {}
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const userToken = this.AuthServices.GetToken();
    if(this.AuthServices.IsLogIn()){
      request = request.clone({
      setHeaders:{
        Authorization: `Bearer ${userToken}`
      },
      });
    }
  return next.handle(request);
}
}
