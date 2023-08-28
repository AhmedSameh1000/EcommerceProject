using Core.Models;

namespace Api.DTOs
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string URL { get; set; }
        public virtual string productType { get; set; }

        public virtual string ProductBrand { get; set; }


    }
}
