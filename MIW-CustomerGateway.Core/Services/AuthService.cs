using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using MIW_CustomerGateway.Core.Mappers;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;

namespace MIW_CustomerGateway.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthAgent _authAgent;

        public AuthService(IAuthAgent authAgent)
        {
            _authAgent = authAgent;
        }

        public async Task<string> Login(Credentials credentials)
        {
            return AuthMapper.LoginResponseToString(
                await _authAgent.Login(AuthMapper.CredentialsToCredentialsMessage(credentials)));
        }

        public async Task<bool> Register(Credentials credentials)
        {
            return AuthMapper.RegisterResponseToBool(
                await _authAgent.Register(AuthMapper.CredentialsToCredentialsMessage(credentials)));
        }
    }
}