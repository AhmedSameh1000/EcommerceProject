using Api.DTOs;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;

namespace InfraStructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext Context;
        private readonly IWebHostEnvironment _host;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductRepository(
            AppDbContext Context,
            IWebHostEnvironment host,
            IHttpContextAccessor httpContextAccessor
           )
        {
            this.Context = Context;
            _host = host;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Product> CreateProductAsync(ProductToCreateDTO productTo)
        {
            string RootPath = _host.WebRootPath;
            var ImageUrl = "";
            string fileName = Guid.NewGuid().ToString();
            string imageFolderPath = Path.Combine(RootPath, @"Images");
            string extension = Path.GetExtension(productTo.Image.FileName);
            using (FileStream fileStreams = new(Path.Combine(imageFolderPath,
                             fileName + extension), FileMode.Create))
            {
                productTo.Image.CopyTo(fileStreams);
            }
            ImageUrl = @$"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/Images/" + fileName + extension;
        
            var ProductToSave = new Product()
            {
                Description=productTo.Description,
                Name=productTo.Name,
                Price=productTo.Price,
                ProductBrandId = productTo.ProductBrandId,
                ProductTypeId = productTo.ProductTypeId,
                URL=ImageUrl
            };
              Context.Products.Add(ProductToSave);
             await  Context.SaveChangesAsync();

            return  ProductToSave;
        }

        public async Task DeleteProductAsync(int id)
        {
            var Product = await Context.Products.FindAsync(id);
            if (Product is null)
                return ;

            string RootPath = _host.WebRootPath.Replace("\\\\", "\\");
            var imageNameToDelete = System.IO.Path.GetFileNameWithoutExtension(Product.URL);
            var EXT = Path.GetExtension(Product.URL);
            var oldImagePath = $@"{RootPath}\Images\{imageNameToDelete}{EXT}";
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            Context.Remove(Product);
            await Context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await Context.ProductBrands.ToListAsync();
        }

        public async Task<ProductPaginationResponse> GetProductsAsync(int page=1)
        {
            var PageResult = 5f;
            var PageCount = Math.Ceiling(Context.Products.Count() / PageResult);



            var Products= await Context.Products
                .Include(p=>p.productType)
                .Include(p=>p.ProductBrand)
                .Skip((page-1)*(int)PageResult)
                .Take((int)PageResult)
                .Select(p=>new ProductToReturnDto()
                {
                    Description = p.Description,    
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    URL = p.URL,
                    ProductBrand= p.ProductBrand.Name,
                    productType = p.productType.Name
                })
                .ToListAsync();


            var ProductResponse = new ProductPaginationResponse
            {
                products = Products,
                currentPage = page,
                PageCount = (int)PageCount,
                ProductsCount = Context.Products.Count(),
            };
            return ProductResponse;
        }

        public async Task<Product> GetProductsByIdAsync(int id)
        {
            return await Context.Products
                .Include(p => p.productType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await Context.ProductTypes.ToListAsync();

        }
    }
}
