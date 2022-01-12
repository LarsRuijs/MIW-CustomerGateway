using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIW_CustomerGateway.Grpc.Agents.Interfaces
{
    public interface IProductAgent
    {
        Task<ProductMessage> Create(CreateProductRequest request);
        Task<List<ProductMessage>> GetAll(GetAllProductsRequest request);
        Task<ProductMessage> GetSingle(GetSingleProductRequest request);
    }
}