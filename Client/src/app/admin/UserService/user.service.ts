import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pagination } from 'src/app/shared/Models/Paging';
import { Product } from 'src/app/shared/Models/Product';
import { params } from 'src/app/shared/Models/params';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private Http:HttpClient) { }
  GetUsers(AllParams:params):Observable<Pagination<any[]>>{
    let params=new HttpParams();
    if(AllParams.SearchInput)
     params=params.append("search",AllParams.SearchInput);   


     if(AllParams.page)
     params=params.append("page",AllParams.page);

     return this.Http.get<Pagination<Product[]>>(environment.baseUrl+"User/AllUsers",{params:params})
   }
   DeleteUser(id:any){
    return this.Http.delete(environment.baseUrl+"User/DeleteUser/"+id)
   }
}
