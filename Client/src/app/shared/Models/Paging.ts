import { Product } from "./Product"

export interface Pagination<T>{
    currentPage:number,
    pageCount:number,
    productsCount:number,
    itemsPerPage:number
    products:T
}