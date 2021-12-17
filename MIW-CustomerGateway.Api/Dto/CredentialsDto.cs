using System.ComponentModel.DataAnnotations;

namespace MIW_CustomerGateway.Api.Dto
{
    public class CredentialsDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}