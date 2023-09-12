using Api.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class cartItem
    {
        public int id { get; set; }
        public int productId { get; set; }
        [ForeignKey("productId")]
        public virtual Product product { get; set; }
        public int count { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
       public virtual User User { get; set; }

    }
}
