using System.Collections.Generic;
using System.Threading.Tasks;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAll();
        public Task<Customer> Get(long id);
        public Task<Customer> Create(Customer customer);
    }
}