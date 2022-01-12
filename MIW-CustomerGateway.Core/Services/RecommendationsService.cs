using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Mappers;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;

namespace MIW_CustomerGateway.Core.Services
{
    public class RecommendationsService : IRecommendationsService
    {
        private readonly IRecommendationsAgent _recommendationsAgent;

        public RecommendationsService(IRecommendationsAgent recommendationsAgent)
        {
            _recommendationsAgent = recommendationsAgent;
        }
        
        public async Task<List<Product>> GetRecommendations(List<long> productIds)
        {
            List<Product> recommendations = new List<Product>();
            foreach (var productResponse in await _recommendationsAgent
                .GetRecommendations(RecommendationsMapper
                    .ProductIdsToGetRecommendationsRequest(productIds)))
            {
                recommendations.Add(RecommendationsMapper.ProductMessageToProduct(productResponse));
            }

            return recommendations;
        }

        public async Task<List<Product>> GetRecommendationsByBasketId(long basketId)
        {
            List<Product> recommendations = new List<Product>();
            foreach (var productResponse in await _recommendationsAgent
                .GetRecommendationsByBasketId(RecommendationsMapper.BasketIdToBasketIdMessage(basketId))) 
            {
                recommendations.Add(RecommendationsMapper.ProductMessageToProduct(productResponse));
            }

            return recommendations;
        }
    }
}