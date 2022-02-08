using System.Collections.Generic;
using System.Security.Claims;

namespace ApiRestAspNet5_01.Authentication
{
    public interface ITokenService
    {
        string GeneratedAccessToken(IEnumerable<Claim> claims);
        string GeneratedRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiratedToken(string token);
    }
}
