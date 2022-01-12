using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Core.Services.Interfaces
{
    public interface IRecommendationsService
    {
        Task<List<Product>> GetRecommendations(List<long> productIds);
        
        Task<List<Product>> GetRecommendationsByBasketId(long basketId);
    }
}