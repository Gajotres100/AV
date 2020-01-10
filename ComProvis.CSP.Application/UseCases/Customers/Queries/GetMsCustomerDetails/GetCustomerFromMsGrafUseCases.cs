using ComProvis.CSP.Application.Interfaces;
using ComProvis.CSP.Application.Interfaces.Repositories;
using omProvis.CSP.Application.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Customers.Queries.GetMsCustomerDetails
{
    public class GetCustomerFromMsGraf : IQuery<GetCustomerModel>
    {
        internal Guid TenantId { get; set; }

        public GetCustomerFromMsGraf(Guid tenantId)
        {
            TenantId = tenantId;
        }

        internal sealed class GetCustomerQueryHandler : IQueryHandler<GetCustomerFromMsGraf, GetCustomerModel>
        {
            private readonly ICustomerReadRepository _customerReadRepository;
            private readonly IUserReadRepository _userReadRepository;
            private ICspClient _cspClient { get; set; }

            public GetCustomerQueryHandler(ICspClient cspClient, ICustomerReadRepository customerReadRepository, IUserReadRepository userReadRepository)
            {
                _cspClient = cspClient;
                _customerReadRepository = customerReadRepository;
                _userReadRepository = userReadRepository;
            }

            public async Task<GetCustomerModel> HandleAsync(GetCustomerFromMsGraf query)
            {
                var customer = await _cspClient.GetCustomerAsync(query.TenantId.ToString());

                var customerDb = await _customerReadRepository.Get(query.TenantId);
                var user = await _userReadRepository.GetFirstByCustomerId(query.TenantId);

                return new GetCustomerModel
                {
                    Domain = customer?.Domain,
                    Address=customer?.Address,
                    PhoneNumber=customer?.PhoneNumber,
                    City=customer?.City,
                    Country=customer?.Country,
                    PostalCode=customer?.PostalCode,
                    Name=customer?.Name,
                    Margin = customerDb?.Margin,
                    Email = user?.Username
                };                
            }
        }
    }
}
