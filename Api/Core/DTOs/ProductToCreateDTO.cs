
using Microsoft.AspNetCore.Http;

namespace Core.DTOs
{
    public class ProductToCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public int ProductTypeId { get; set; }


        public int ProductBrandId { get; set; }
    }
}
