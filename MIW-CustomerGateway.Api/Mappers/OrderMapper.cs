using System.Collections.Generic;
using MIW_CustomerGateway.Api.Dto;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Grpc;

namespace MIW_CustomerGateway.Api.Mappers
{
    public class OrderMapper
    {
        public static Order OrderDtoToOrder(OrderDto orderDto)
        {
            List<Product> products = new List<Product>();
            foreach (ProductDto productDto in orderDto.Products)
            {
                products.Add(ProductMapper.ProductDtoToProduct(productDto));
            }

            return new()
            {
                Id = orderDto.Id,
                Customer = CustomerMapper.CustomerDtoToCustomer(orderDto.Customer),
                Products = products
            };
        }

        public static OrderDto OrderToOrderDto(Order order)
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (Product product in order.Products)
            {
                productDtos.Add(ProductMapper.ProductToProductDto(product));
            }

            return new()
            {
                Id = order.Id,
                Customer = CustomerMapper.CustomerToCustomerDto(order.Customer),
                Products = productDtos
            };
        }

        public static Order CreateOrderDtoToOrder(CreateOrderDto createOrderDto)
        {
            List<Product> products = new List<Product>();
            foreach (ProductDto productDto in createOrderDto.Products)
            {
                products.Add(ProductMapper.ProductDtoToProduct(productDto));
            }
            
            return new()
            {
                Customer = CustomerMapper.CustomerDtoToCustomer(createOrderDto.Customer),
                Products = products
            };
        }
    }
}