import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CartItemService {

  constructor(private Http:HttpClient) { }


  SendCartItem(CartItem:any)
  {

  return this.Http.post(environment.baseUrl+"CartItem/"+"SaveCartItem",CartItem);
  }

}
