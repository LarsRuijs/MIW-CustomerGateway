using System;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Grpc;

namespace MIW_CustomerGateway.Core.Mappers
{
    public class CustomerMapper
    {
        public static Customer CustomerResponseToCustomer(CustomerResponse customerResponse)
        {
            return new()
            {
                Id = customerResponse.Id,
                CredentialsId = customerResponse.CredentialsId,
                GivenName = customerResponse.GivenName,
                FamilyName = customerResponse.FamilyName,
                DateOfBirth = DateTime.UnixEpoch.AddMilliseconds(customerResponse.DateOfBirth),
                PostalCode = customerResponse.PostalCode,
                HouseNumber = customerResponse.HouseNumber
            };
        }

        public static CreateCustomerRequest CustomerToCreateCustomerRequest(Customer customer)
        {
            return new()
            {
                CredentialsId = customer.CredentialsId,
                GivenName = customer.GivenName,
                FamilyName = customer.FamilyName,
                DateOfBirth = ((DateTimeOffset) customer.DateOfBirth).ToUnixTimeMilliseconds(),
                PostalCode = customer.PostalCode,
                HouseNumber = customer.HouseNumber
            };
        }
    }
}