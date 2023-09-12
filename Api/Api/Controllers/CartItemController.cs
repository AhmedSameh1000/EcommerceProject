using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository cartItemRepository;
        private readonly IMapper mapper;
        public CartDto  CartDto { get; set; }
        public CartItemController(ICartItemRepository cartItemRepository
           ,IMapper mapper)
        {
            this.cartItemRepository = cartItemRepository;
            this.mapper = mapper;
        }

        [HttpPost("SaveCartItem")]
        public IActionResult SaveCartItem(CartItemToAdd cartItemDTO)
        {
           
             cartItemRepository.Add(cartItemDTO);
            return Ok(cartItemDTO);
        }

        [HttpGet("GetCartItems/{id}")]
        
        public async Task<IActionResult> GetCartItems(string id)
        {

            CartDto = new CartDto()
            {
                CartItems=await cartItemRepository.GetAll(id)
            };

            foreach (var item in CartDto.CartItems)
            {
                CartDto.cartTotal += (double)item.product.Price * item.count;
                CartDto.piecesCount += item.count;
            }

            return Ok(CartDto);

        }

        [HttpGet("Increment/{id}")]
        public IActionResult IncrementCartItem(int id)
        {
            cartItemRepository.IncrementCartItem(id);
            return Ok();
        }   
        [HttpGet("Decrement/{id}")]
        public IActionResult DecrementCartItem(int id)
        {
            cartItemRepository.DecrementCartItem(id);
            return Ok();
        }    
        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveCartItem(int id)
        {
            cartItemRepository.RemoveCartItem(id);
            return Ok();
        }




    }
}
