using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICartItemRepository
    {
        public void Add(CartItemToAdd cartItem);

        public Task<List<cartItem>> GetAll(string userId);
        public void IncrementCartItem(int id);
        public void DecrementCartItem(int id);
        public void RemoveCartItem(int id);

        public void RemoveRange(List<cartItem> items);
        public void UpdateOrderHeader(OrderHeader orderHeader);

        public void UpdateOrderHeaderStatus(int id, string OrderStatus,string PaymentStatus);
        public void UpdateOrderHeaderPayment(int id, string sessionId,string paymentIntentId);
         


        public void UpdateOrderDetail(OrderDetail orderDetail);

        public void AddOrderHeader(OrderHeader orderHeader);
        public void AddOrderDetail(OrderDetail orderDetail);

        public OrderHeader GetOrderHeader(int id);






    
    

    
    
    
    }



}



