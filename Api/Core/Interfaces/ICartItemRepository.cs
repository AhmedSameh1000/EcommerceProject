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
         void Add(CartItemToAdd cartItem);

         Task<List<cartItem>> GetAll(string userId);
         void IncrementCartItem(int id);
         void DecrementCartItem(int id);
         void RemoveCartItem(int id);

         void RemoveRange(List<cartItem> items);
         void UpdateOrderHeader(OrderHeader orderHeader);

         void UpdateOrderHeaderStatus(int id, string OrderStatus,string PaymentStatus);
         void UpdateOrderHeaderPayment(int id, string sessionId,string paymentIntentId);
         List<UserDataWithPackageData> userDataWithpackageData();
         void UpdateOrderDetail(OrderDetail orderDetail);

         void AddOrderHeader(OrderHeader orderHeader);
         void AddOrderDetail(OrderDetail orderDetail);
        
         void AddPaymentPackage(PaymentPackage paymentPackage);
         OrderHeader GetOrderHeader(int id);

         List<PaymentPackage> GetPaymentPackagesByUserId(string  userId);

         void StartProcessing(string userId,string reciverId);
         void CompleteTask(string userId, string reciverId);
         List<UserDataWithPackageData> GetOrdersByUserId(string userId);
    }



}



