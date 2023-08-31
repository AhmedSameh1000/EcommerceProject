using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PaginationParams
    {
        public int? page { get; set; } = 1;
        public int? BrandId { get; set; }   

        public int? TypeId { get; set; }
        public string? Search { get; set; }

    }
}
