using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIW_CustomerGateway.Grpc.Agents.Interfaces
{
    public interface IProductAgent
    {
        Task<ProductResponse> Create(CreateProductRequest request);
        Task<List<ProductResponse>> GetAll(GetAllProductsRequest request);
        Task<ProductResponse> GetSingle(GetSingleProductRequest request);
    }
}