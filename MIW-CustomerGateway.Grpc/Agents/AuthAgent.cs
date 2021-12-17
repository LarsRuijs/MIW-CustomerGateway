using System.Threading.Tasks;
using Grpc.Net.Client;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MIW_CustomerGateway.Grpc.Agents
{
    public class AuthAgent : IAuthAgent
    {
        private readonly string _address;
        private readonly ILogger<AuthAgent> _logger;

        public AuthAgent(ILogger<AuthAgent> logger, IConfiguration configuration)
        {
            _address = configuration.GetSection("ServiceUrl")["AuthService"];
            _logger = logger;
        }
        
        public async Task<RegisterResponse> Register(CredentialsMessage message)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_address);
            var client = new AuthService.AuthServiceClient(channel);
            _logger.LogInformation($"Auth Register Request sent to {_address}");
            return await client.RegisterAsync(message);
        }

        public async Task<LoginResponse> Login(CredentialsMessage message)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_address);
            var client = new AuthService.AuthServiceClient(channel);
            _logger.LogInformation($"Auth Login Request sent to {_address}");
            return await client.LoginAsync(message);
        }
    }
}