using MIW_CustomerGateway.Api.Dto;
using MIW_CustomerGateway.Core.Models;

namespace MIW_CustomerGateway.Api.Mappers
{
    public class AuthMapper
    {
        public static Credentials CredentialsDtoToCredentials(CredentialsDto credentialsDto)
        {
            return new()
            {
                Email = credentialsDto.Email,
                Password = credentialsDto.Password
            };
        }

        public static Credentials RegisterCredentialsDtoToCredentials(RegisterCredentialsDto credentialsDto)
        {
            return new()
            {
                Email = credentialsDto.Email,
                Password = credentialsDto.Password
            };
        }
    }
}