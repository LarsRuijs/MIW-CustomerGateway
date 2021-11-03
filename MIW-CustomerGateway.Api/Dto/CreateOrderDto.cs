using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MIW_CustomerGateway.Api.Dto
{
    public class CreateOrderDto
    {
        [Required]
        public CustomerDto Customer { get; set; }
        [Required]
        public List<ProductDto> Products { get; set; }
    }
}