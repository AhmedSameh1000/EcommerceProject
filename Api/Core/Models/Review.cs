using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Review
    {
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public int productId { get; set; }
        public string? reviewText { get; set; }
        public int reviewStarts { get; set; }
    }

}
