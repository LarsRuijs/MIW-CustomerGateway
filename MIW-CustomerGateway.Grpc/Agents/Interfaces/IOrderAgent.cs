using System.Threading.Tasks;

namespace MIW_CustomerGateway.Grpc.Agents.Interfaces
{
    public interface IOrderAgent
    {
        Task<OrderResponse> Create(CreateOrderRequest request);
    }
}