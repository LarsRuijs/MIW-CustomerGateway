using System.ComponentModel.DataAnnotations;

namespace MIW_CustomerGateway.Api.Dto
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public decimal Discount { get; set; }
        [Required]
        public string ImgLink { get; set; }
    }
}