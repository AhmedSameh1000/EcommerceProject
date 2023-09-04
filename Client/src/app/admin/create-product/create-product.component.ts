import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MatDialog, MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ShopService } from 'src/app/shop/Services/shop.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {
  constructor(private MatDialogRef:MatDialogRef<CreateProductComponent>,
    private MatDialog:MatDialog,
    private FormBuilder:FormBuilder,
    private ShopService:ShopService,
    private toaster:ToastrService){
    
  } 
  ngOnInit(): void {
  this.InitializeForm()
  this.loadBrands()
  this.loadTypes()
  }

  Brands:any
  loadBrands(){
    this.ShopService.GetBrands().subscribe({
      next:(res)=>{
        this.Brands=res
      }
    })
  }
  Types:any
  loadTypes(){
    this.ShopService.GetTypes().subscribe({
      next:(res)=>{
        this.Types=res
      }
    })
  }
  FormGroup!:FormGroup
  Close(){
    this.MatDialogRef.close()
  }
  InitializeForm()
  {
    this.FormGroup=this.FormBuilder.group({
      name:['',[Validators.required]],
      description:['',[Validators.required]],
      price:['',[Validators.required]],
      image:['',[Validators.required]],
      productTypeId:['',[Validators.required]],
      ProductBrandId:['',[Validators.required]]
    })
  }

  CreateNewProduct(img:HTMLInputElement){
    if(img.value==""){
      this.toaster.error("please Select an image");
      return;
    }
    if(this.FormGroup.invalid){
      return;
    }

    let MyData = new FormData();
    MyData.append(
      'image',
      this.FormGroup.value['image'],
      this.FormGroup.value['image'].name
    );
    MyData.append("name",this.FormGroup.value.name);
    MyData.append("description",this.FormGroup.value.description);
    MyData.append("price",this.FormGroup.value.price);
    MyData.append("productTypeId",this.FormGroup.value.productTypeId);
    MyData.append("ProductBrandId",this.FormGroup.value.ProductBrandId);
    this.ShopService.CreateProduct(MyData).subscribe((res:any) => {
      this.toaster.success("Product Created Succesfuly");
      this.MatDialogRef.close(res)
      }
    )
  } 

  SelectImage($event: any) {
    this.FormGroup.get('image')?.setValue($event.target.files[0]);
  }
  
  SelectType(event:any){
    this.FormGroup.get("productTypeId")?.setValue(event.target.value)
  console.log(event.target.value)
  }
  SelectBrand(event:any){
    this.FormGroup.get("ProductBrandId")?.setValue(event.target.value)
    console.log(event.target.value)
  }
  
 

}
