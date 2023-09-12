using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repositories
{
    public class CartItemRepository :ICartItemRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CartItemRepository(AppDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Add(CartItemToAdd cartItem)
        {
            var CartItemFromDb=context.cartItems.FirstOrDefault(c=>c.UserId == cartItem.UserId
            &&c.productId==cartItem.productId);

        
            if(CartItemFromDb == null )
            {
                var _cartItem = mapper.Map<cartItem>(cartItem);  
                 context.cartItems.Add(_cartItem);
            }
            else
            {
                CartItemFromDb.count+=cartItem.count;
            }           
                 context.SaveChanges();
        }

        public void DecrementCartItem(int id)
        {
            var cartItem = context.cartItems.Find(id);
           
                if (cartItem.count <= 1)
                {
                    context.cartItems.Remove(cartItem);
                }
                else
                {
                    cartItem.count--;
                }
                context.SaveChanges();
           
        }

        public async Task<List<cartItem>> GetAll(string userId)
        {
            var CartItems=await context.cartItems.Where(c=>c.UserId==userId).ToListAsync();
            return CartItems;
        }

        public void IncrementCartItem(int id)
        {
            var cartItem = context.cartItems.Find(id);
            if (cartItem != null)
            {
                cartItem.count++;
                context.SaveChanges();
            }
        }

        public void RemoveCartItem(int id)
        {
            var cartItem = context.cartItems.Find(id);
            if (cartItem != null)
            {
                context.cartItems.Remove(cartItem);
                context.SaveChanges();
            }
        }
    }

}
