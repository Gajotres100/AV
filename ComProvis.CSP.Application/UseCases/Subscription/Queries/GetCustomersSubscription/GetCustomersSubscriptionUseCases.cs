using ComProvis.CSP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Subscription.Queries.GetCustomersSubscription
{
    public class GetCustomersSubscriptionUseCases : IQuery<List<GetCustomersSubscriptionModel>>
    {
        internal Guid TenantId { get; set; } 
        public GetCustomersSubscriptionUseCases(Guid tenantId)
        {
            TenantId = tenantId;
        }
    }

    internal sealed class GetCustomersSubscriptionQueryHandler : IQueryHandler<GetCustomersSubscriptionUseCases, List<GetCustomersSubscriptionModel>>
    {
        private ICspClient CspClient { get; set; }
        public GetCustomersSubscriptionQueryHandler(ICspClient cspClient)
        {
            CspClient = cspClient;
        }

        public async Task<List<GetCustomersSubscriptionModel>> HandleAsync(GetCustomersSubscriptionUseCases query)
        {
            var customeSubscription = await CspClient.GetCustomersSubscriptionAsync(query.TenantId.ToString());

            return customeSubscription?.Select(x => new GetCustomersSubscriptionModel
            {
                FriendlyName = x.FriendlyName,
                Quantity = x.Quantity,
                SubscriptionId = x.Id
            }).ToList();
        }
    }
}
