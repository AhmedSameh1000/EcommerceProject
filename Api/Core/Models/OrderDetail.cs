using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        [Required]
        public int orderHeaderId { get; set; }
        [ValidateNever]
        [ForeignKey("orderHeaderId")]
        public virtual OrderHeader orderHeader { get; set; }

        [Required]
        public int productId { get; set; }
        [ValidateNever]
        public virtual Product product { get; set; }

        public int count { get; set; }
        public double price { get; set; }
    }
}
