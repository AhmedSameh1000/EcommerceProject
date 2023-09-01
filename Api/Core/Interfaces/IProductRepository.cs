﻿using Core.DTOs;
using Core.Models;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductsByIdAsync(int id);
        Task<ProductPaginationResponse> GetProductsAsync(PaginationParams @params);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<Product> CreateProductAsync(ProductToCreateDTO createDTO);
        Task DeleteProductAsync(int id);


        Task<List<ProductImages>> GetImagesForSomeProducts();
    
    }
}
