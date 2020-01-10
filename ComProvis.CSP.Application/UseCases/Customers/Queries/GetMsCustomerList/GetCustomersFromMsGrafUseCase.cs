using ComProvis.CSP.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ComProvis.CSP.Application.Customers.Queries.GetCustomersFromMsGraf
{
    public class GetCustomersFromMsGrafUseCase : IQuery<List<GetCustomersModel>>
    {        
        public GetCustomersFromMsGrafUseCase()
        {
            
        }        

        internal sealed class GetCustomersListQueryHandler : IQueryHandler<GetCustomersFromMsGrafUseCase, List<GetCustomersModel>>
        {
            private ICspClient CspClient { get; set; }

            public GetCustomersListQueryHandler(ICspClient cspClient)
            {
                CspClient = cspClient;
            }

            public async Task<List<GetCustomersModel>> HandleAsync(GetCustomersFromMsGrafUseCase query)
            {
                var customers =  await CspClient.GetCustomersAsync();

                return customers.Select(x => new GetCustomersModel
                {
                    Name = x.Name,
                    TenantId = x.Id,
                    DomainName=x.Domain
                    
                }).ToList();                
            }
        }
    }
}
