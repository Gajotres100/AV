using AutoMapper;
using D = ComProvis.CSP.Domain.Customers;
using E = ComProvis.CSP.Persistance.Entities;

namespace ComProvis.CSP.Persistance
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<D.Customer, E.Customer>()
                .ForMember(dest => dest.Guid, opts => opts.MapFrom(src => src.Id));
            CreateMap<E.Customer, D.Customer>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Guid));
        }
    }
}
