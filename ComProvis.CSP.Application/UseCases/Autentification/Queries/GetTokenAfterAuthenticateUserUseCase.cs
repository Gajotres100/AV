using ComProvis.CSP.Application.Interfaces;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using ComProvis.CSP.Common.Utils;
using ComProvis.CSP.Application.Interfaces.Repositories;
using ComProvis.CSP.Common;

namespace ComProvis.CSP.Application.UseCases.Autentification.Queries
{
    public class GetTokenAfterAuthenticateUserUseCase : IQuery<GetTokenAfterAuthenticateUserModel>
    {
        internal string Username { get; set; }
        internal string Password { get; set; }

        public GetTokenAfterAuthenticateUserUseCase(string username, string password)
        {
            Username = username;
            Password = password;
        }

        internal sealed class GetTokenAfterAuthenticateUserHandler : IQueryHandler<GetTokenAfterAuthenticateUserUseCase, GetTokenAfterAuthenticateUserModel>
        {
            private IUserReadRepository UserReadRepository { get; set; }
            public IJwtTokenProvider JwtTokenProvider { get; set; }

            public GetTokenAfterAuthenticateUserHandler(IUserReadRepository userReadRepository, IJwtTokenProvider jwtTokenProvider)
            {
                UserReadRepository = userReadRepository;
                JwtTokenProvider = jwtTokenProvider;
            }            

            public async Task<GetTokenAfterAuthenticateUserModel> HandleAsync(GetTokenAfterAuthenticateUserUseCase query)
            {
                var user = await UserReadRepository.AuteticateUser(query.Username, MD5.CreateMD5(query.Password));
                if (user == null) return null;
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var token = JwtTokenProvider.GenerateJwtToken(user.Id.ToString(), "User", user?.Username);

                return new GetTokenAfterAuthenticateUserModel
                { 
                    Token = jwtSecurityTokenHandler.WriteToken(token)
                };
            }
        }
    }
}