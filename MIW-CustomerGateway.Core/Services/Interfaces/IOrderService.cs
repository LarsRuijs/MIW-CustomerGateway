using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Core.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAll();
        public Task<Order> Get(long id);
        public Task<Order> Create(Order order);
    }
}