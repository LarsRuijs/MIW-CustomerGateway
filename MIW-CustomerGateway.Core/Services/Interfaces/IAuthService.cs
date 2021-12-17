using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Core.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Login(Credentials credentials);

        public Task<bool> Register(Credentials credentials);
    }
}