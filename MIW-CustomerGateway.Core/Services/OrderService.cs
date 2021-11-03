using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Mappers;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;

namespace MIW_CustomerGateway.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderAgent _orderAgent;

        public OrderService(IOrderAgent orderAgent)
        {
            _orderAgent = orderAgent;
        }

        public Task<List<Order>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> Create(Order order)
        {
            order = OrderMapper.OrderResponseToOrder(
                await _orderAgent.Create(
                    OrderMapper.OrderToCreateOrderRequest(order)));
            
            return order;
        }
    }
}