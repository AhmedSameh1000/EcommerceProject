namespace Core.Models
{
    public class BasketItem
    {
        public string id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string url { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}