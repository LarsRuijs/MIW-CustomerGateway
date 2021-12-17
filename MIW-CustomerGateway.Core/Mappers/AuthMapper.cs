using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Grpc;

namespace MIW_CustomerGateway.Core.Mappers
{
    public class AuthMapper
    {
        public static bool RegisterResponseToBool(RegisterResponse registerResponse)
        {
            return registerResponse.Registered;
        }

        public static string LoginResponseToString(LoginResponse loginResponse)
        {
            return loginResponse.Token;
        }

        public static CredentialsMessage CredentialsToCredentialsMessage(Credentials credentials)
        {
            return new()
            {
                Email = credentials.Email,
                Password = credentials.Password
            };
        }
    }
}