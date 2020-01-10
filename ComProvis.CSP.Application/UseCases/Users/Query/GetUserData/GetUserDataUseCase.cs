

using AutoMapper;
using ComProvis.CSP.Application.Interfaces;
using ComProvis.CSP.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Users.Query.GetUserData
{
    public class GetUserDataUseCase : IQuery<GetUserDataModel>
    {
        public GetUserDataUseCase()
        {

        }

        internal sealed class GetUserDataQueryHandler : IQueryHandler<GetUserDataUseCase, GetUserDataModel>
        {
            IHttpContextAccessor HttpContextAccessor { get; set; }
            IUserReadRepository UserReadRepository { get; set; }
            private readonly IMapper _mapper;
            public GetUserDataQueryHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, IUserReadRepository userReadRepository)
            {
                HttpContextAccessor = httpContextAccessor;
                UserReadRepository = userReadRepository;
                _mapper = mapper;
            }

            public async Task<GetUserDataModel> HandleAsync(GetUserDataUseCase query)
            {
                var username = HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("upn"))?.Value;
                return _mapper.Map<GetUserDataModel>(await UserReadRepository.GetByUsername(username));
            }
        }
    }
}
