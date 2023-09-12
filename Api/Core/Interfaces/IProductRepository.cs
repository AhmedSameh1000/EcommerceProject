using Core.DTOs;
using Core.Models;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<cartItemDTO> GetProductByIdAsync(int id);
        Task<ProductPaginationResponse> GetProductsAsync(PaginationParams @params);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<Product> CreateProductAsync(ProductToCreateDTO createDTO);
        Task DeleteProductAsync(int id);
        Task<List<ProductImages>> GetImagesForSomeProducts();

        Task<ProductBrand> CreateBrand(BrandOrTypeToCreate Object);
        Task<ProductType> Createtype(BrandOrTypeToCreate Object); 
        
        void DeleteBrand(int id);
        void DeleteType(int id);
    


    }
}
