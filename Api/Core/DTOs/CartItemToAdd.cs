using Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CartItemToAdd
    {
        public int productId { get; set; }
        public int count { get; set; }
        public string UserId { get; set; }
    }
}
