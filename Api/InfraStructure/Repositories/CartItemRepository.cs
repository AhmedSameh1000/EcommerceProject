using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using InfraStructure.Seeding;
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

        public void AddOrderDetail(OrderDetail orderDetail)
        {
           context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }

        public void AddOrderHeader(OrderHeader orderHeader)
        {
            context.OrderHeaders.Add(orderHeader);
            context.SaveChanges();
        }

        public void AddPaymentPackage(PaymentPackage paymentPackage)
        {
            var CurrentPaymentPackage = context.PaymentPackages.FirstOrDefault(c => c.ProductId == paymentPackage.ProductId
            && c.UserId == paymentPackage.UserId && c.Pending.ToLower() == Constant.StatusPending.ToLower());

            if(CurrentPaymentPackage == null )
            {
                context.PaymentPackages.Add(paymentPackage);
            }
            else
            {
                CurrentPaymentPackage.Count+=paymentPackage.Count;
                CurrentPaymentPackage.Price += paymentPackage.Price;
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

        public OrderHeader GetOrderHeader(int id)
        {
            return context.OrderHeaders.FirstOrDefault(c => c.id == id);
        }

        public List<UserDataWithPackageData> userDataWithpackageData()
        {
            

            var TotalPrice= context.PaymentPackages.Where(c => c.Pending != Constant.StatusCompleted).Select(c=>c.Price).ToList();
            var CurrntTotlaPrice = TotalPrice.Sum();
            var UserData= context.PaymentPackages.Where(c=>c.Pending!=Constant.StatusCompleted).Select(c=>new UserDataWithPackageData()
            {
                userId=c.UserId,
                Address=c.Address,
                OrderStatus = c.Pending,
                phoneNumber=c.PhoneNumber,
                Price= CurrntTotlaPrice.Value,
                UserName = c.UserName,
                reciverId=c.ReciverId,
            }).AsEnumerable()
              .DistinctBy(c=>c.userId)
              .ToList();

            return UserData;
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

        public void RemoveRange(List<cartItem> items)
        {
            context.RemoveRange(items);
            context.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
           context.OrderDetails.Update(orderDetail);
        }

        public void UpdateOrderHeader(OrderHeader orderHeader)
        {
            context.OrderHeaders.Update(orderHeader);
            context.SaveChanges();
        }

        public void UpdateOrderHeaderPayment(int id, string sessionId, string paymentIntentId)
        {
            var OrderHeader=context.OrderHeaders.FirstOrDefault(o=>o.id==id);

            OrderHeader.paymentDate = DateTime.Now;
            OrderHeader.sessionId= sessionId;
            OrderHeader.paymentIntentId=paymentIntentId;
            context.SaveChanges();
        }

        public void UpdateOrderHeaderStatus(int id, string OrderStatus, string PaymentStatus)
        {
            var OrderHeader=context.OrderHeaders.FirstOrDefault(c=>c.id==id);

            if(OrderHeader != null)
            {
                OrderHeader.orderStatus=OrderStatus;
                if(PaymentStatus!=null) 
                {
                    OrderHeader.paymentStatus=PaymentStatus;
                }
            }

            context.SaveChanges() ;
        }

        public List<PaymentPackage> GetPaymentPackagesByUserId(string userId)
        {
           var PaymentPackages=context.PaymentPackages.Where(c=>c.UserId==userId&& c.Pending!=Constant.StatusCompleted).ToList();
            return PaymentPackages;
        }

        public void StartProcessing(string userId,string reciverId)
        {
            var PaymentPackages = context.PaymentPackages.Where(c => c.UserId == userId && c.Pending.ToLower() == Constant.StatusPending.ToLower()).ToList();

            foreach (var Package in PaymentPackages)
            {
                Package.Pending=Constant.StatusInProcess.ToLower();
                Package.ReciverId= reciverId;
                context.SaveChanges();
            }
        
        }

        public void CompleteTask(string userId, string reciverId)
        {
            var PaymentPackages = context.PaymentPackages.Where(c => c.UserId == userId && c.Pending.ToLower() == Constant.StatusInProcess.ToLower()).ToList();

            foreach (var Package in PaymentPackages)
            {
                Package.Pending = Constant.StatusCompleted.ToLower();
                context.SaveChanges();
            }
        }
    }


}
