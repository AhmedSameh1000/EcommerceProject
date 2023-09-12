using Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class cartItemDTO
    {
        public int productId { get; set; }

        public  ProductToReturnDto? product { get; set; }
        public int count { get; set; }
        public string UserId { get; set; }      

    }
}
