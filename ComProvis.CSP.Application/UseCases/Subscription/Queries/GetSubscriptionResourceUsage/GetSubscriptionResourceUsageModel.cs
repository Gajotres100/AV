using System;

namespace ComProvis.CSP.Application.UseCases.Subscription.Queries.GetSubscriptionResourceUsage
{
    public class GetSubscriptionResourceUsageModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public double QuantityUsed { get; set; }
        public string Unit { get; set; }      
        public string Name { get; set; }
        public double TotalCost { get; set; }
     
    }
}
