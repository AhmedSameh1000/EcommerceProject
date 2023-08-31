import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Type } from '@angular/core';
import { Observable } from 'rxjs';
import { Brand } from 'src/app/shared/Models/Brand';
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
  GetBrands():Observable<Brand[]>{
    return this.Http.get<Brand[]>(environment.baseUrl+"Product/Brands")
  }
  GetTypes():Observable<type[]>{
    return this.Http.get<type[]>(environment.baseUrl+"Product/Types")
  }
}
