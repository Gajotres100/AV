using AutoMapper;
using ComProvis.CSP.Application.Interfaces;
using ComProvis.CSP.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Users.Query
{
    public class GetUserByUsernameUseCase : IQuery<GetUserModel>
    {
        public string Username { get; set; }
        public GetUserByUsernameUseCase(string username)
        {
            Username = username;
        }
    }

    internal sealed class GetUserHandler : IQueryHandler<GetUserByUsernameUseCase, GetUserModel>
    {
        IUserReadRepository UserReadRepository { get; set; }
        private readonly IMapper _mapper;
        public GetUserHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            UserReadRepository = userReadRepository;
            _mapper = mapper;
        }

        public async Task<GetUserModel> HandleAsync(GetUserByUsernameUseCase query) => _mapper.Map<GetUserModel>(await UserReadRepository.GetByUsername(query.Username));
    }
}
