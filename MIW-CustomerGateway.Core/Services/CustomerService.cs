using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Mappers;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;
using MIW_CustomerGateway.Grpc.Agents.Interfaces;

namespace MIW_CustomerGateway.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerAgent _customerAgent;

        public CustomerService(ICustomerAgent customerAgent)
        {
            _customerAgent = customerAgent;
        }

        public Task<List<Customer>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Customer> Create(Customer customer)
        {
            customer = CustomerMapper.CustomerResponseToCustomer(
                await _customerAgent.Create(
                    CustomerMapper.CustomerToCreateCustomerRequest(customer)));

            return customer;
        }
    }
}