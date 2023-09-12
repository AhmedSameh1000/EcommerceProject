import { Product } from "./Product";

export interface CartItem
{
    id:number,
    productId:number,
    count:number,
    product:Product
}