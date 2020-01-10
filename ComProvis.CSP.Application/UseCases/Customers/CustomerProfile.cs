using AutoMapper;
using ComProvis.CSP.Application.UseCases.Customers.Commands.ChangePassword;
using ComProvis.CSP.Domain.Customers;

namespace ComProvis.CSP.Application.UseCases.Customers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<ChangePasswordModel, Customer>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.TenantId)); ;
        }
    }
}
