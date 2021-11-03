using System;

namespace MIW_CustomerGateway.Core.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public long CredentialsId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
    }
}