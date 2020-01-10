using ComProvis.CSP.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Subscription.Queries.GetSubscriptionResourceUsage
{
    public class GetSubscriptionResourceUsageUseCase : IQuery<List<GetSubscriptionResourceUsageModel>>
    {
        internal string SubscrptionId { get; set; }
        internal Guid TenantId { get; set; }

        public GetSubscriptionResourceUsageUseCase(Guid tenantId, string subscrptionId)
        {
            SubscrptionId = subscrptionId;
            TenantId = tenantId;
        }
    }

    internal sealed class GetSubscriptionResourceUsageHandler : IQueryHandler<GetSubscriptionResourceUsageUseCase, List<GetSubscriptionResourceUsageModel>>
    {
        ICspClient CspClient { get; set; }
        public GetSubscriptionResourceUsageHandler(ICspClient cspClient)
        {
            CspClient = cspClient;
        }
        public async Task<List<GetSubscriptionResourceUsageModel>> HandleAsync(GetSubscriptionResourceUsageUseCase query)
        {
            var resourceUsages = await CspClient.GetSubscriptionResourceUsageAsync(query.TenantId.ToString(), query.SubscrptionId);

            return resourceUsages?.Select(x => new GetSubscriptionResourceUsageModel
            {
                Category = x.Category,
                Id = x.Id,
                Subcategory = x.Subcategory,
                Name=x.Name,
                QuantityUsed=x.QuantityUsed,
                TotalCost=x.TotalCost,
                Unit=x.Unit
               

            }).ToList();
        }
    }
}
