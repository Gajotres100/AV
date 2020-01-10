using AutoMapper;
using ComProvis.CSP.Application.UseCases.Users.Query;
using ComProvis.CSP.Application.UseCases.Users.Query.GetUserData;
using ComProvis.CSP.Domain.Customers;

namespace ComProvis.CSP.Application.UseCases.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserModel>();
            CreateMap<User, GetUserDataModel>(); 
        }
    }
}
