using System;
using System.ComponentModel.DataAnnotations;

namespace MIW_CustomerGateway.Api.Dto
{
    public class CreateCustomerDto
    {
        [Required]
        public long CredentialsId { get; set; }
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string HouseNumber { get; set; }
    }
}