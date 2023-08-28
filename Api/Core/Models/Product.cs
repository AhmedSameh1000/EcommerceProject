using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string URL { get; set; }
        public virtual ProductType  productType { get; set; }
        public int ProductTypeId { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }




    }
}

