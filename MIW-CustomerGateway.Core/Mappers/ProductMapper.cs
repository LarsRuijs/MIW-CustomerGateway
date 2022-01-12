using System;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Grpc;

namespace MIW_CustomerGateway.Core.Mappers
{
    public class ProductMapper
    {
        public static Product ProductResponseToProduct(ProductMessage productResponse)
        {
            return new()
            {
                Id = productResponse.Id,
                Name = productResponse.Name,
                Company = productResponse.Company,
                Price = productResponse.Price,
                Discount = productResponse.Discount,
                ImgLink = productResponse.ImgLink
            };
        }

        public static CreateProductRequest ProductToCreateProductRequest(Product product)
        {
            return new()
            {
                Name = product.Name,
                Company = product.Company,
                Price = Decimal.ToInt32(product.Price),
                Discount = Decimal.ToInt32(product.Discount),
                ImgLink = product.ImgLink
            };
        }

        public static GetSingleProductRequest ProductIdToGetSingleProductRequest(long productId)
        {
            return new()
            {
                Id = productId
            };
        }

        public static GetAllProductsRequest ProductCountToGetAllProductsRequest(int productCount)
        {
            return new()
            {
                Count = productCount
            };
        }
    }
}