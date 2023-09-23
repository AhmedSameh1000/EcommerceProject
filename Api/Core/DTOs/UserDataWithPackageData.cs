using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UserDataWithPackageData
    {
        public string userId {  get; set; }
        public string phoneNumber { get; set; }
        public string UserName { get; set; }

        public string OrderStatus { get; set; }

        public string Count { get; set; }

        public string Address { get; set; }
        public decimal Price { get; set; }
        public string? reciverId { get; set; }


    }
}
