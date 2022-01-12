using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MIW_CustomerGateway.Grpc.Agents
{
    public class ProductAgent : IProductAgent
    {
        private readonly string _address;
        private readonly ILogger<ProductAgent> _logger;

        public ProductAgent(ILogger<ProductAgent> logger, IConfiguration configuration)
        {
            _address = configuration.GetSection("ServiceUrl")["ProductService"];
            _logger = logger;
        }

        public async Task<ProductMessage> Create(CreateProductRequest request)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_address);
            var client = new ProductService.ProductServiceClient(channel);
            _logger.LogInformation($"Create Product Request sent to {_address}");
            return await client.CreateProductAsync(request);

        }

        public async Task<List<ProductMessage>> GetAll(GetAllProductsRequest request)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_address);
            var client = new ProductService.ProductServiceClient(channel);
            _logger.LogInformation($"Get All Products Request sent to {_address}");
            var responses = client.GetAllProducts(request);

            List<ProductMessage> productResponses = new List<ProductMessage>();
            await foreach (var response in responses.ResponseStream.ReadAllAsync())
            {
                productResponses.Add(response);
            }
            return productResponses;
        }

        public async Task<ProductMessage> GetSingle(GetSingleProductRequest request)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_address);
            _logger.LogInformation($"Get Single Product Request sent to {_address}");
            var client = new ProductService.ProductServiceClient(channel);
            return await client.GetSingleProductAsync(request);
        }
    }
}