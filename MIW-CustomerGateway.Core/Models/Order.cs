using System.Collections.Generic;

namespace MIW_CustomerGateway.Core.Models
{
    public class Order
    {
        public long Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
    }
}