using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Core.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll();
        public Task<Product> Get(long id);
        public Task<Product> Create(Product product);
    }
}