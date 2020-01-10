using System;
using System.Collections.Generic;

namespace ComProvis.Csp.Infrastructure.MS.Entities.GetSubscriptionUsageRecordsResponse
{
    public class Attributes
    {
        public string objectType { get; set; }
    }

    public class Item
    {
        public string status { get; set; }
        public string offerId { get; set; }
        public string resourceId { get; set; }
        public string id { get; set; }
        public string resourceName { get; set; }
        public string name { get; set; }
        public double totalCost { get; set; }
        public string currencyLocale { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Self
    {
        public string uri { get; set; }
        public string method { get; set; }
        public List<object> headers { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
    }

    public class Attributes2
    {
        public string objectType { get; set; }
    }

    public class GetSubscriptionUsageRecordsResponse
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
        public Links links { get; set; }
        public Attributes2 attributes { get; set; }
    }
}
