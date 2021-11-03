using System;
using System.Collections.Generic;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Grpc;

namespace MIW_CustomerGateway.Core.Mappers
{
    public class OrderMapper
    {
        public static Order OrderResponseToOrder(OrderResponse orderResponse)
        {
            List<Product> products = new List<Product>();
            foreach (OrderProduct orderProduct in orderResponse.Products)
            {
                products.Add(OrderProductToProduct(orderProduct));
            }
            
            return new()
            {
                Id = orderResponse.Id,
                Customer = OrderCustomerToCustomer(orderResponse.Customer),
                Products = products
            };
        }

        public static CreateOrderRequest OrderToCreateOrderRequest(Order order)
        {
            CreateOrderRequest createOrderRequest = new CreateOrderRequest();
            foreach (Product product in order.Products)
            {
                createOrderRequest.Products.Add(productToOrderProduct(product));
            }

            createOrderRequest.Customer = customerToOrderCustomer(order.Customer);

            return createOrderRequest;
        }

        private static Customer OrderCustomerToCustomer(OrderCustomer orderCustomer)
        {
            return new()
            {
                Id = orderCustomer.Id,
                CredentialsId = orderCustomer.CredentialsId,
                GivenName = orderCustomer.GivenName,
                FamilyName = orderCustomer.FamilyName,
                DateOfBirth = DateTime.UnixEpoch.AddMilliseconds(orderCustomer.DateOfBirth),
                PostalCode = orderCustomer.PostalCode,
                HouseNumber = orderCustomer.HouseNumber
            };
        }

        private static OrderCustomer customerToOrderCustomer(Customer customer)
        {
            return new()
            {
                Id = customer.Id,
                CredentialsId = customer.CredentialsId,
                GivenName = customer.GivenName,
                FamilyName = customer.FamilyName,
                DateOfBirth = customer.DateOfBirth.Ticks,
                PostalCode = customer.PostalCode,
                HouseNumber = customer.HouseNumber
            };
        }

        private static Product OrderProductToProduct(OrderProduct orderProduct)
        {
            return new()
            {
                Id = orderProduct.Id,
                Name = orderProduct.Name,
                Company = orderProduct.Company,
                Price = orderProduct.Price,
                Discount = orderProduct.Discount,
                ImgLink = orderProduct.ImgLink
            };
        }

        private static OrderProduct productToOrderProduct(Product product)
        {
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Company = product.Company,
                Price = Decimal.ToInt32(product.Price),
                Discount = Decimal.ToInt32(product.Discount),
                ImgLink = product.ImgLink
            };
        }
    }
}