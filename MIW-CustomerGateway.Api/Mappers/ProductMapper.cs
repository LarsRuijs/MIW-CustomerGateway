using MIW_CustomerGateway.Api.Dto;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Api.Mappers
{
    public class ProductMapper
    {
        public static Product ProductDtoToProduct(ProductDto productDto)
        {
            return new()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Company = productDto.Company,
                Price = productDto.Price,
                Discount = productDto.Discount,
                ImgLink = productDto.ImgLink
            };
        }

        public static ProductDto ProductToProductDto(Product product)
        {
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Company = product.Company,
                Price = product.Price,
                Discount = product.Discount,
                ImgLink = product.ImgLink
            };
        }
        
        public static Product CreateProductDtoToProduct(CreateProductDto createProductDto)
        {
            return new()
            {
                Id = 0,
                Name = createProductDto.Name,
                Company = createProductDto.Company,
                Price = createProductDto.Price,
                Discount = createProductDto.Discount,
                ImgLink = createProductDto.ImgLink
            };
        }
    }
}