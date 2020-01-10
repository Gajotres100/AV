using System;

namespace ComProvis.CSP.Application.UseCases.Subscription.Queries.GetCustomersSubscription
{
    public class GetCustomersSubscriptionModel
    {
        public string FriendlyName { get; set; }
        public int Quantity { get; set; }
        public Guid SubscriptionId { get; set; }        
    }
}