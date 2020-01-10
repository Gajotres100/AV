using System;

namespace ComProvis.CSP.Application.UseCases.Subscription.Queries.GetSubscriptionResourceUsage
{
    public class GetSubscriptionUsageRecordsModel
    {
        public string ResourceName { get; set; }
        public string Status { get; set; }
        public string ResourceId { get; set; }
        public string Id { get; set; }
        public double TotalCost { get; set; }
        public string CurrencyLocale { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string OfferId { get; set; }
    }
}