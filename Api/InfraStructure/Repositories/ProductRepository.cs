using Api.DTOs;
using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InfraStructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext Context;
        private readonly IWebHostEnvironment _host;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public ProductRepository(
            AppDbContext Context,
            IWebHostEnvironment host,
            IHttpContextAccessor httpContextAccessor,
              IMapper mapper
           )
        {
            this.Context = Context;
            _host = host;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        public async Task<ProductBrand> CreateBrand(BrandOrTypeToCreate Object)
        {
           var Brand = new ProductBrand()
           {
               Name=Object.Name
           };
            Context.ProductBrands.Add(Brand);   
            await Context.SaveChangesAsync();
            return Brand;
        
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

        public async Task<ProductType> Createtype(BrandOrTypeToCreate Object)
        {
            var Type = new ProductType()
            {
                Name = Object.Name
            };
            Context.ProductTypes.Add(Type);
            await Context.SaveChangesAsync();
            return Type;
        }

        public void DeleteBrand(int id)
        {
            var Brand = Context.ProductBrands.Find(id);

   
            if(Brand != null)
            {
                 Context.ProductBrands.Remove(Brand);
                 Context.SaveChanges();
            }
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

        public void DeleteType(int id)
        {
            var Type = Context.ProductTypes.Find(id);

            if (Type != null)
            {
                Context.ProductTypes.Remove(Type);
                 Context.SaveChanges();
            }
        }

        public async Task<List<ProductImages>> GetImagesForSomeProducts()
        {
            var ProductsCount=await Context.Products.CountAsync();
            var Count=ProductsCount>=10?10:ProductsCount;

            var Images=await Context.Products.Take(Count).ToListAsync();
            var ImagesToReturn=mapper.Map<List<ProductImages>>(Images);
            return ImagesToReturn;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var Brands=await Context.ProductBrands.ToListAsync();

            return Brands;
        }

        public async Task<ProductPaginationResponse> GetProductsAsync(PaginationParams @params)
        {
            var _itemsPerPage = 6f;
            var PageCount = Math.Ceiling(Context.Products.Count() / _itemsPerPage);



            var Products = Context.Products
                .Include(p => p.productType)
                .Include(p => p.ProductBrand)
                .Skip((@params.page.Value - 1) * (int)_itemsPerPage)
                .Take((int)_itemsPerPage);
              
            if (@params.TypeId.HasValue)
            {
                Products =Products.Where(p => p.ProductTypeId == @params.TypeId.Value);
            }     
            if (@params.BrandId.HasValue)
            {
                Products = Products.Where(p => p.ProductBrandId == @params.BrandId.Value);
            } 
            if (!string.IsNullOrEmpty(@params.Search))
            {
                Products = Products.Where(p => p.Name.ToLower().Contains(@params.Search.ToLower()));
            }

            var AllProducts = await Products.ToListAsync();



            var ProductToReturn = mapper.Map<List<ProductToReturnDto>>(AllProducts);

            var ProductResponse = new ProductPaginationResponse
            {
                products = ProductToReturn,
                PageCount = (int)PageCount,
                itemsPerPage = _itemsPerPage,
                ProductsCount = Context.Products.Count(),
                currentPage=@params.page.Value               
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
