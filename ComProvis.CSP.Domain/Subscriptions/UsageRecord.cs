using System;

namespace ComProvis.CSP.Domain.Subscriptions
{
    public class UsageRecord
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
