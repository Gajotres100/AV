using ComProvis.CSP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Subscription.Queries.GetSubscriptionResourceUsage
{
    public class GetSubscriptionUsageRecordsUseCase : IQuery<List<GetSubscriptionUsageRecordsModel>>
    {
        internal Guid TenantId { get; set; }
        public GetSubscriptionUsageRecordsUseCase(Guid tenantId)
        {
            TenantId = tenantId;
        }
    }

    internal sealed class GetSubscriptionUsageRecordsHandler : IQueryHandler<GetSubscriptionUsageRecordsUseCase, List<GetSubscriptionUsageRecordsModel>>
    {
        private ICspClient CspClient { get; set; }
        public GetSubscriptionUsageRecordsHandler(ICspClient cspClient)
        {
            CspClient = cspClient;
        }

        public async Task<List<GetSubscriptionUsageRecordsModel>> HandleAsync(GetSubscriptionUsageRecordsUseCase query)
        {
            var resourceUsage = await CspClient.GetSubscriptionUsageRecordsAsync(query.TenantId.ToString());

            return resourceUsage?.Select(x => new GetSubscriptionUsageRecordsModel
            {
                ResourceName = x.ResourceName,
                Status=x.Status,
                CurrencyLocale=x.CurrencyLocale,
                Id=x.Id,
                LastModifiedDate=x.LastModifiedDate,
                ResourceId=x.ResourceId,
                TotalCost=x.TotalCost,
                OfferId=x.OfferId
            }).ToList();
        }
    }
}
