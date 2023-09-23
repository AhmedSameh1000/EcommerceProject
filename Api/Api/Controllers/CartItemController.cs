using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using InfraStructure.Seeding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe.Checkout;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository cartItemRepository;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

       
        public CartItemController(ICartItemRepository cartItemRepository
           ,IMapper mapper,UserManager<User> userManager)
        {
            this.cartItemRepository = cartItemRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost("SaveCartItem")]
        public IActionResult SaveCartItem(CartItemToAdd cartItemDTO)
        {
           
             cartItemRepository.Add(cartItemDTO);
            return Ok(cartItemDTO);
        }

        [HttpGet("StartProcessing/{userId}/{ReciverId}")]
        public IActionResult StartProcessing(string userId, string ReciverId)
        {
            cartItemRepository.StartProcessing(userId,ReciverId);
            return Ok();
        }
               
        [HttpGet("CompleteProcessing/{userId}/{ReciverId}")]
        public IActionResult CompleteProcessing(string userId, string ReciverId)
        {
            cartItemRepository.CompleteTask(userId,ReciverId);
            return Ok();
        }



        [HttpGet("GetCartItems/{id}")]
        public async Task<IActionResult> GetCartItems(string id)
        {

            CartDto cartDto = new CartDto()
            {
                CartItems=await cartItemRepository.GetAll(id)
            };

            foreach (var item in cartDto.CartItems)
            {
                cartDto.cartTotal += (double)item.product.Price * item.count;
                cartDto.piecesCount += item.count;
            }

            return Ok(cartDto);

        }
        [HttpGet("GetUserPackegs/{id}")]
        public IActionResult GetUserPackegs(string id)
        {
            var Packages=cartItemRepository.GetPaymentPackagesByUserId(id);
            return Ok(Packages);
        }

        [HttpGet("userDataWithpackageData")]
        public IActionResult PaymentPackages()
        {
            var Packges = cartItemRepository.userDataWithpackageData();
            return Ok(Packges);
        }



        [HttpGet("SummaryGet/{userId}")]
        public IActionResult Summary(string userId)
        {
            CartDto cartDto = new CartDto()
            {
                CartItems = cartItemRepository.GetAll(userId).Result.ToList(),
                orderHeader = new OrderHeader()
            };

            var CurrentUser=userManager.FindByIdAsync(userId);
            cartDto.orderHeader.userId = userId;

            cartDto.orderHeader.name = CurrentUser.Result.FirstName+" " + CurrentUser.Result.LastName;
            cartDto.orderHeader.phoneNumber =CurrentUser.Result.PhoneNumber;

            cartDto.orderHeader.city = CurrentUser.Result.City;
         
            foreach (var item in cartDto.CartItems)
            {

                cartDto.cartTotal +=(double) (item.product.Price * item.count);

                cartDto.orderHeader.orderTotal +=(double) (item.product.Price * item.count);
                cartDto.piecesCount += item.count;
            }
            return Ok(cartDto);
        }


        [HttpPost("SummaryPost/{userId}")]
        public IActionResult SummaryPost([FromBody]userData userData, string userId)
        {
            var cartDto = new CartDto();
            var OrderHeader = new OrderHeader();
            cartDto.orderHeader= OrderHeader;
            var User = userManager.FindByIdAsync(userId).Result;
            cartDto.CartItems = cartItemRepository.GetAll(userId).Result;


            cartDto.orderHeader.paymentIntentId = Constant.PaymentStatusPending;
            cartDto.orderHeader.orderStatus = Constant.StatusPending;
            cartDto.orderHeader.orderDate = DateTime.Now;
            cartDto.orderHeader.userId = userId;
            cartDto.orderHeader.phoneNumber = userData.Phone;
            cartDto.orderHeader.streetAddress = userData.address;
            cartDto.orderHeader.city = userData.city;
            cartDto.orderHeader.name = userData.name;

            
            foreach (var item in cartDto.CartItems)
            {
                cartDto.cartTotal += (double)(item.product.Price * item.count);
                cartDto.orderHeader.orderTotal +=(double) (item.product.Price * item.count);

                cartDto.piecesCount += item.count;
            }


            cartItemRepository.AddOrderHeader(cartDto.orderHeader);
            
            foreach (var item in cartDto.CartItems)
            {
                OrderDetail orderDetail = new()
                {
                    productId = item.productId,
                    orderHeaderId = cartDto.orderHeader.id,
                    price =(double) item.product.Price,
                    count = item.count
                };
                cartItemRepository.AddOrderDetail(orderDetail);
            }

            //Stripe Payment
            var domain = "https://localhost:7159/";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>()
        ,
                Mode = "payment",
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                SuccessUrl = $"http://localhost:4200/successPaymentPage?id={cartDto.orderHeader.id}",
                CancelUrl = "http://localhost:4200/failurePaymentPage"
            };

            foreach (var item in cartDto.CartItems)
            {
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.product.Price * 100),
                            Currency = "egp",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.product.Name,
                                Description = item.product.Description, 
                            },

                        },
                        Quantity = item.count
                    };
                    options.LineItems.Add(sessionLineItem);
                }
            }
            var service = new SessionService();
            Session session = service.Create(options);
   
            cartItemRepository.UpdateOrderHeaderPayment(cartDto.orderHeader.id, session.Id, session.PaymentIntentId);
            return Ok(session);
        }
        [HttpGet("OrderConfirmation")]
        public async Task<IActionResult> OrderConfirmation([FromQuery]int id)
        {
            var OrderHeader = cartItemRepository.GetOrderHeader(id);
            var User = userManager.FindByIdAsync(OrderHeader.userId).Result;
            var service = new SessionService();
            Session session = service.Get(OrderHeader.sessionId);

            if (session.PaymentStatus.ToLower() == "paid")
            {
                cartItemRepository.UpdateOrderHeaderStatus(id,Constant.StatusApproved,Constant.PaymentStatusApproved);
            }

            var CartItems = await cartItemRepository.GetAll(OrderHeader.userId);

            foreach (var cartItem in CartItems)
            {
                var PaymentPackage = new PaymentPackage()
                {
                    Address=OrderHeader.streetAddress,
                    Brand=cartItem.product.ProductBrand.Name,
                    Type=cartItem.product.productType.Name,
                    Count=cartItem.count,
                    Description=cartItem.product.Description,
                    Name=cartItem.product.Name,
                    PhoneNumber=OrderHeader.phoneNumber,
                    Price=(cartItem.product.Price*cartItem.count),
                    ProductImage=cartItem.product.URL,
                    UserId=User.Id, 
                    Pending=Constant.StatusPending.ToLower(),
                    ProductId=cartItem.productId,
                    UserName=OrderHeader.name,
                    
                };
                cartItemRepository.AddPaymentPackage(PaymentPackage);
            }

            cartItemRepository.RemoveRange(CartItems);
            return Ok(id);   
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
