using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIW_CustomerGateway.Grpc.Agents.Interfaces
{
    public interface IRecommendationsAgent
    {
        Task<List<RecommendationsProductMessage>> GetRecommendations(GetRecommendationsRequest request);

        Task<List<RecommendationsProductMessage>> GetRecommendationsByBasketId(BasketIdMessage request);
    }
}