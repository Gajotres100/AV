using System.IdentityModel.Tokens.Jwt;

namespace ComProvis.CSP.Common.Utils
{
    public interface IJwtTokenProvider
    {
        JwtSecurityToken GenerateJwtToken(string guid, string role, string username);
    }
}