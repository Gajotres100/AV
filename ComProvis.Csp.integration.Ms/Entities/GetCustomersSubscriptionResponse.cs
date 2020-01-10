using System;
using System.Collections.Generic;

namespace ComProvis.Csp.Infrastructure.MS.Entities.GetCustomersSubscriptionResponse
{
    public class Offer
    {
        public string uri { get; set; }
        public string method { get; set; }
        public List<object> headers { get; set; }
    }

    public class Self
    {
        public string uri { get; set; }
        public string method { get; set; }
        public List<object> headers { get; set; }
    }

    public class Links
    {
        public Offer offer { get; set; }
        public Self self { get; set; }
    }

    public class Attributes
    {
        public string etag { get; set; }
        public string objectType { get; set; }
    }

    public class Item
    {
        public Guid id { get; set; }
        public string entitlementId { get; set; }
        public string friendlyName { get; set; }
        public int quantity { get; set; }
        public string unitType { get; set; }
        public string creationDate { get; set; }
        public string effectiveStartDate { get; set; }
        public string commitmentEndDate { get; set; }
        public string status { get; set; }
        public bool autoRenewEnabled { get; set; }
        public string billingType { get; set; }
        public string contractType { get; set; }
        public Links links { get; set; }
        public string orderId { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Attributes2
    {
        public string objectType { get; set; }
    }

    public class GetCustomersSubscriptionResponse
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
    }
}
