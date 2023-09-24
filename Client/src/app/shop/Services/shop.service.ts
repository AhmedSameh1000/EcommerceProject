import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Type } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from 'src/app/shared/Models/Brand';
import { CartItem } from 'src/app/shared/Models/CartItem';
import { Pagination } from 'src/app/shared/Models/Paging';
import { Product } from 'src/app/shared/Models/Product';
import { type } from 'src/app/shared/Models/Type';
import { params } from 'src/app/shared/Models/params';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  constructor(private Http:HttpClient) { }
  GetProducts(AllParams:params):Observable<Pagination<Product[]>>{
   let params=new HttpParams();
   if(AllParams.brandIdSelected)
    params=params.append("brandId",AllParams.brandIdSelected);
   
   if(AllParams.TypeIdSelected)
    params=params.append("typeId",AllParams.TypeIdSelected);
   
   if(AllParams.page)
    params=params.append("page",AllParams.page);

   if(AllParams.SearchInput)
    params=params.append("search",AllParams.SearchInput);
   
    return this.Http.get<Pagination<Product[]>>(environment.baseUrl+"Product/Products",{params:params})
  }
  GetBrands(){
    return this.Http.get<Brand[]>(environment.baseUrl+"Product/Brands")
  }
  GetTypes(){
    return this.Http.get<type[]>(environment.baseUrl+"Product/Types")
  }
  GetProduct(id:number){
    return this.Http.get<CartItem>(environment.baseUrl+`Product/${id}`)
  }
  GetProductsImages(){
    return this.Http.get<Product[]>(environment.baseUrl+"Product/ProductsImages")
  }
  CreateProduct(Prodcut:any){
  return this.Http.post(environment.baseUrl+"Product/CreateProductAsync",Prodcut)
  }
  DeleteProduct(id:number){
  return  this.Http.delete(environment.baseUrl+"Product/DeleteProductAsync/"+id)
  }
  CreateBrand(Brand:any){
    return this.Http.post(environment.baseUrl+"Product/CreateBrand",Brand)
  }
  DeleteBrand(id:any){
    return this.Http.delete(environment.baseUrl+"Product/DeleteBrand/"+id)
  }
  CreateType(Type:any){
    return this.Http.post(environment.baseUrl+"Product/CreateType",Type)
  }
  DeleteType(id:any){
    return this.Http.delete(environment.baseUrl+"Product/DeleteType/"+id)
  }
  GetCartItems(id:string){
    return this.Http.get(environment.baseUrl+"CartItem/GetCartItems/"+id)
  }
  IncrementCartItem(id:any){
    return this.Http.get(environment.baseUrl+"CartItem/Increment/"+id)
  }
  DecrementCartItem(id:any){
    return this.Http.get(environment.baseUrl+"CartItem/Decrement/"+id)
  }
  RemoveCartItem(id:any){
    return this.Http.delete(environment.baseUrl+"CartItem/Remove/"+id)
  }
  StartPay(userid:any,userData:any){
    return this.Http.post(environment.baseUrl+"CartItem/SummaryPost/"+userid,userData)
  }

  public summaryGet(userId:any){
    return this.Http.get(environment.baseUrl+`CartItem/SummaryGet/${userId}`)
  }
  public summaryPost(userId:any){
    return this.Http.post(environment.baseUrl+`CartItem/SummaryPost/${userId}`,{})
  }
  public OrderConfirmation(id:any){
    return this.Http.get(environment.baseUrl+`CartItem/OrderConfirmation?id=${id}`)
  }
  public GetPackges(){
    return this.Http.get(environment.baseUrl+`CartItem/userDataWithpackageData`)
  }
  public GetUSerPackagesById(id:any){
    return this.Http.get(environment.baseUrl+"CartItem/GetUserPackegs/"+id)
  }

  public startProcessing(userId:any,reciverId:any){
    return this.Http.get(environment.baseUrl+"CartItem/StartProcessing/"+userId+"/"+reciverId)
  }
  public CompleteProcessing(userId:any,reciverId:any){
    return this.Http.get(environment.baseUrl+"CartItem/CompleteProcessing/"+userId+"/"+reciverId)
  }
  public GetOrders(userId:any){
    return this.Http.get(environment.baseUrl+"CartItem/GetOrdersById/"+userId)
  }
  public AddReview(Review:any){
    return this.Http.post(environment.baseUrl+"Product/AddReview",Review)
  }
  public GetReviews(id:any){
    return this.Http.get(environment.baseUrl+"Product/Reviews/"+id)
  }
}



