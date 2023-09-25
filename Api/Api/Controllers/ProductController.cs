using Api.DTOs;
using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IReviewRepository reviewRepository;

        public ProductController(
            IProductRepository productRepository,
            IMapper mapper,
            IReviewRepository reviewRepository
            )
        {

            this.productRepository = productRepository;
            this.mapper = mapper;
            this.reviewRepository = reviewRepository;
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpDelete("DeleteBrand/{id}")]
        public  Task DeleteBrand(int id)
        {
            productRepository.DeleteBrand(id);
            return Task.CompletedTask; 
        }
        [Authorize(Roles ="Admin,Moderator")]
        [HttpDelete("DeleteType/{id}")]
        public Task Deletetype(int id)
        {
            productRepository.DeleteType(id);
            return Task.CompletedTask;
        }



        [Authorize(Roles = "Admin,Moderator")]

        [HttpPost("CreateBrand")]
        public async Task<IActionResult> CreateBrand(BrandOrTypeToCreate obj)
        {
            var Brands = await productRepository.GetProductBrandsAsync();
            if (Brands.Any(c => c.Name.ToLower() == obj.Name.ToLower()))
            {
                var Message = "the Brand is Already Exist";
                return Ok(Message);
            }


            var Brand = await productRepository.CreateBrand(obj);
            return Ok(Brand);  
        }
        [Authorize(Roles = "Admin,Moderator")]

        [HttpPost("CreateType")]
        public async Task<IActionResult> Createtype(BrandOrTypeToCreate obj)
        {
            var Types = await productRepository.GetProductTypesAsync();

            if (Types.Any(c => c.Name.ToLower() == obj.Name.ToLower()))
            {
                var Message = "the Type is Already Exist";
                return Ok(Message);
            }


            var Type = await productRepository.Createtype(obj);
            return Ok(Type);  
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationParams? param)
        {
            var ProductPagination = await productRepository.GetProductsAsync(param);
           
            return Ok(ProductPagination);
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpDelete("DeleteProductAsync/{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            await productRepository.DeleteProductAsync(id);
            return Ok();
        }

    
        [HttpGet("ProductsImages")]
        public async Task<IActionResult> GetProductsImages()
        {
            var Images=await productRepository.GetImagesForSomeProducts();
            return Ok(Images);
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost("CreateProductAsync")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductToCreateDTO productdto)
        {
            var product = await productRepository.CreateProductAsync(productdto);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var ProductCartItem = await productRepository.GetProductByIdAsync(id);
            return Ok(ProductCartItem);
        }

        [HttpGet("Types")]
       
        public async Task<IActionResult> GetProductTypes()
        {
            return Ok(await productRepository.GetProductTypesAsync());
        }
        
        [HttpGet("Brands")]
        
        public async Task<IActionResult> GetProductBrands()
        {
            return Ok(await productRepository.GetProductBrandsAsync());
        } 
        [HttpPost("AddReview")]

        public IActionResult AddReview(Review review)
        {
            reviewRepository.AddReview(review);
            return Ok();
        }
        [HttpGet("Reviews/{id}")]
        public IActionResult GetReviews(int id)
        {
           var Reviews= reviewRepository.GetReviews(id);
            return Ok(Reviews);
        }
    }
}
