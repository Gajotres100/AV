using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ComProvis.CSP.Common.Utils
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private IConfiguration Configuration { get; set; }
        public JwtTokenProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public JwtSecurityToken GenerateJwtToken(string guid, string role, string username)
        {
            var claimdata = new[] { new Claim(ClaimTypes.NameIdentifier, guid), new Claim(ClaimTypes.Role, role), new Claim(ClaimTypes.Upn, username) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: Configuration["Tokens:Issuer"],                
                expires: DateTime.Now.AddHours(1),
                claims: claimdata,
                signingCredentials: signInCredentials
                );

            return token;

        }
    }
}
