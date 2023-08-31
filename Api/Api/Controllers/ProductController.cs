using Api.DTOs;
using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly ProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(
            ProductRepository productRepository,
            IMapper mapper
            )
        {

            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        [HttpGet("Products")]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationParams? param)
        {
            var ProductPagination = await productRepository.GetProductsAsync(param);
           
            return Ok(ProductPagination);
        }
        [HttpDelete("DeleteProductAsync/{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            await productRepository.DeleteProductAsync(id);
            return Ok();
        }


        [HttpPost("CreateProductAsync")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductToCreateDTO productdto)
        {
            var product = await productRepository.CreateProductAsync(productdto);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await productRepository.GetProductsByIdAsync(id);
            var ProductToReturn = mapper.Map<ProductToReturnDto>(Product);

            return Ok(ProductToReturn);
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
    }
}
