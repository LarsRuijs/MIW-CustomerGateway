using System;
using System.Collections.Generic;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Grpc;

namespace MIW_CustomerGateway.Core.Mappers
{
    public static class RecommendationsMapper
    {
        // public static GetRecommendationsRequest ProductsToGetRecommendationsRequest(List<Product> products)
        // {
        //     List<RecommendationsProductMessage> productMessages = new List<RecommendationsProductMessage>();
        //     foreach (var product in products)
        //     {
        //         productMessages.Add(ProductToProductMessage(product));
        //     }
        //
        //     return new()
        //     {
        //         Products = { productMessages }
        //     };
        // }

        public static GetRecommendationsRequest ProductIdsToGetRecommendationsRequest(List<long> productIds)
        {
            return new()
            {
                ProductIds = {productIds}
            };
        }

        public static Recommendation RecommendationMessageToRecommendation(RecommendationMessage recommendationMessage)
        {
            return new()
            {
                Product = ProductMessageToProduct(recommendationMessage.Product),
                Priority = recommendationMessage.Priority
            };
        }

        private static RecommendationsProductMessage ProductToProductMessage(Product product)
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

        public static Product ProductMessageToProduct(RecommendationsProductMessage productMessage)
        {
            return new()
            {
                Id = productMessage.Id,
                Name = productMessage.Name,
                Company = productMessage.Company,
                Price = Decimal.ToInt32(productMessage.Price),
                Discount = Decimal.ToInt32(productMessage.Discount),
                ImgLink = productMessage.ImgLink
            };
        }

        public static BasketIdMessage BasketIdToBasketIdMessage(long basketId)
        {
            return new()
            {
                BasketId = basketId
            };
        }
    }
}