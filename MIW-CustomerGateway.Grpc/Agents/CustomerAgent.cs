using System;
using System.Threading.Tasks;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MIW_CustomerGateway.Grpc.Agents
{
    public class CustomerAgent : ICustomerAgent
    {
        private readonly string _address;
        private readonly ILogger<CustomerAgent> _logger;

        public CustomerAgent(ILogger<CustomerAgent> logger, IConfiguration configuration)
        {
            _address = configuration.GetSection("ServiceUrl")["CustomerService"];
            _logger = logger;
        }
        
        public async Task<CustomerResponse> Create(CreateCustomerRequest request)
        {
            try
            {
                using GrpcChannel channel = GrpcChannel.ForAddress(_address);
                CustomerService.CustomerServiceClient client = new(channel);
                return await client.CreateCustomerAsync(request);
            }
            catch (RpcException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}