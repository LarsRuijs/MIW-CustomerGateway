using System.Threading.Tasks;

namespace MIW_CustomerGateway.Grpc.Agents.Interfaces
{
    public interface IAuthAgent
    {
        Task<RegisterResponse> Register(CredentialsMessage message);

        Task<LoginResponse> Login(CredentialsMessage message);
    }
}