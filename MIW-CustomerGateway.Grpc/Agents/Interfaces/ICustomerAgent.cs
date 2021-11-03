using System.Threading.Tasks;

namespace MIW_CustomerGateway.Grpc.Agents.Interfaces
{
    public interface ICustomerAgent
    {
        Task<CustomerResponse> Create(CreateCustomerRequest request);
    }
}