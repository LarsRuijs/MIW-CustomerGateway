using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;

namespace MIW_CustomerGateway.Grpc.Agents
{
    public class RecommendationsAgent : IRecommendationsAgent
    {
        private readonly string _address;
        private readonly ILogger<RecommendationsAgent> _logger;

        public RecommendationsAgent(ILogger<RecommendationsAgent> logger, IConfiguration configuration)
        {
            _address = configuration.GetSection("ServiceUrl")["RecommendationsService"];
            _logger = logger;
        }
        
        public async Task<List<RecommendationsProductMessage>> GetRecommendations(GetRecommendationsRequest request)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_address);
            var client = new RecommendationsService.RecommendationsServiceClient(channel);
            _logger.LogInformation($"Get All Products Request sent to {_address}");
            var responses = client.GetRecommendations(request);
            
            

            List<RecommendationsProductMessage> productResponses = new List<RecommendationsProductMessage>();
            await foreach (var response in responses.ResponseStream.ReadAllAsync())
            {
                productResponses.Add(response);
            }
            return productResponses;
        }

        public async Task<List<RecommendationsProductMessage>> GetRecommendationsByBasketId(BasketIdMessage request)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_address);
            var client = new RecommendationsService.RecommendationsServiceClient(channel);
            _logger.LogInformation($"Get All Products Request sent to {_address}");
            var responses = client.GetRecommendationsByBasketId(request);

            List<RecommendationsProductMessage> productResponses = new List<RecommendationsProductMessage>();
            await foreach (var response in responses.ResponseStream.ReadAllAsync())
            {
                productResponses.Add(response);
            }
            return productResponses;
        }
    }
}