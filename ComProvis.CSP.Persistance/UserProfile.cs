using AutoMapper;
using D = ComProvis.CSP.Domain.Customers;
using E = ComProvis.CSP.Persistance.Entities;

namespace ComProvis.CSP.Persistance
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<E.User, D.User>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Guid));
            CreateMap<D.User, E.User>()
                .ForMember(dest => dest.Guid, opts => opts.MapFrom(src => src.Id));
        }
    }
}
