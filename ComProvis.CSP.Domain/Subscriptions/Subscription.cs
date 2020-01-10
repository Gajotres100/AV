using System;

namespace ComProvis.CSP.Domain.Subscriptions
{
    public class Subscription : IEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string FriendlyName { get; set; }
        public int Quantity { get; set; }
        
    }
}
