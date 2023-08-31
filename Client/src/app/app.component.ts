import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './shared/Models/Product';
import { Pagination } from './shared/Models/Paging';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(private Http:HttpClient){

  }
  Pagination!:Pagination<Product[]>
  ngOnInit(): void {
    // this.Http.get<Pagination<Product[]>>("https://localhost:7235/api/Product/Products")
    // .subscribe({
    //   next:(res:Pagination<Product[]>)=>{
    //     this.Pagination=res  
    //     console.log(res) 
    //   },
    //   complete:()=>{
    //     console.log("Done")
    //   }
    // })
  }
  title = 'Client';
}
