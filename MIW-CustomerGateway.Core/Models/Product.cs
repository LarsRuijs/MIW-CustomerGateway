namespace MIW_CustomerGateway.Core.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string ImgLink { get; set; }
    }
}