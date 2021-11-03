using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MIW_CustomerGateway.Api.Dto
{
    public class OrderDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public CustomerDto Customer { get; set; }
        [Required]
        public List<ProductDto> Products { get; set; }
    }
}