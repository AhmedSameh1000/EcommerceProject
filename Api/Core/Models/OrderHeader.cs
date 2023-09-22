using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Core.Models
{
    public class OrderHeader
    {
        public int id { get; set; }
        public string userId { get; set; }
        [ValidateNever]
        public virtual User user { get; set; }

        [Required]
        public DateTime ? orderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public double? orderTotal { get; set; }
        public string? orderStatus { get; set; }
        public string? paymentStatus { get; set; }
        public string? trackingNumber { get; set; }
        public string? carrier { get; set; }
        public DateTime? paymentDate { get; set; }
        public DateTime? paymentDueDate { get; set; }

     
        public string? name { get; set; }
  
        public string? phoneNumber { get; set; }
        
        public string? streetAddress { get; set; }
      
        public string? city { get; set; }

        //Stripe Payment Gateway
        public string? sessionId { get; set; }
        public string? paymentIntentId { get; set; }

    }
}
