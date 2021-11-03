using MIW_CustomerGateway.Api.Dto;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Api.Mappers
{
    public class CustomerMapper
    {
        public static Customer CustomerDtoToCustomer(CustomerDto customerDto)
        {
            return new()
            {
                Id = customerDto.Id,
                CredentialsId = customerDto.CredentialsId,
                GivenName = customerDto.GivenName,
                FamilyName = customerDto.FamilyName,
                DateOfBirth = customerDto.DateOfBirth,
                PostalCode = customerDto.PostalCode,
                HouseNumber = customerDto.HouseNumber
            };
        }

        public static CustomerDto CustomerToCustomerDto(Customer customer)
        {
            return new()
            {
                Id = customer.Id,
                CredentialsId = customer.CredentialsId,
                GivenName = customer.GivenName,
                FamilyName = customer.FamilyName,
                DateOfBirth = customer.DateOfBirth,
                PostalCode = customer.PostalCode,
                HouseNumber = customer.HouseNumber
            };
        }

        public static Customer CreateCustomerDtoToCustomer(CreateCustomerDto createCustomerDto)
        {
            return new()
            {
                Id = 0,
                CredentialsId = createCustomerDto.CredentialsId,
                GivenName = createCustomerDto.GivenName,
                FamilyName = createCustomerDto.FamilyName,
                DateOfBirth = createCustomerDto.DateOfBirth,
                PostalCode = createCustomerDto.PostalCode,
                HouseNumber = createCustomerDto.HouseNumber
            };
        }
    }
}