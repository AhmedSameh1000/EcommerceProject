
import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

import { AuthService } from './auth/Auth/auth.service';

import { CreateProductComponent } from './admin/create-product/create-product.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(private authservices:AuthService){

  }


  
  ngOnInit(): void {

  }
  show(){

  }

  title = 'Client';
}
