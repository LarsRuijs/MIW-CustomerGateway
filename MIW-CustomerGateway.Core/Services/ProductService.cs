using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Mappers;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;

namespace MIW_CustomerGateway.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductAgent _productAgent;

        public ProductService(IProductAgent productAgent)
        {
            _productAgent = productAgent;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> products = new List<Product>();
            foreach (var productResponse in await _productAgent.GetAll(ProductMapper.ProductCountToGetAllProductsRequest(0)))
            {
                products.Add(ProductMapper.ProductResponseToProduct(productResponse));
            }

            return products;
        }

        public async Task<Product> Get(long id)
        {
            return ProductMapper.ProductResponseToProduct(
                await _productAgent.GetSingle(
                    ProductMapper.ProductIdToGetSingleProductRequest(id)));
        }

        public async Task<Product> Create(Product product)
        {
            return ProductMapper.ProductResponseToProduct(
                await _productAgent.Create(
                    ProductMapper.ProductToCreateProductRequest(product)));
        }
    }
}