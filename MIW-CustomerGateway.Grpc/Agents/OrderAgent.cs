using System;
using System.Threading.Tasks;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MIW_CustomerGateway.Grpc.Agents
{
    public class OrderAgent : IOrderAgent
    {
        private readonly string _address;
        private readonly ILogger<OrderAgent> _logger;

        public OrderAgent(ILogger<OrderAgent> logger, IConfiguration configuration)
        {
            _address = configuration.GetSection("ServiceUrl")["OrderService"];
            _logger = logger;
        }
        
        public async Task<OrderResponse> Create(CreateOrderRequest request)
        {
            try
            {
                using GrpcChannel channel = GrpcChannel.ForAddress(_address);
                OrderService.OrderServiceClient client = new(channel);
                return await client.CreateOrderAsync(request);
            }
            catch (RpcException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}