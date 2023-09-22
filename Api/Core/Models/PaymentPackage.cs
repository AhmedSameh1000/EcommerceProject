using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PaymentPackage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Address { get; set; }
        public string? Brand { get; set; }
        public decimal? Price { get; set; }
        public string? ProductImage { get; set; }
        public string? PhoneNumber { get; set; }
        public int?    Count { get; set; }
        public string? UserId { get; set; }
        public string? ReciverId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(ReciverId))]
        public virtual User Reciver { get; set; }

        public string Pending { get; set; }

        public int ProductId { get; set; }
        public string UserName { get; set; }
    }


}
