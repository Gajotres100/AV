using System;
using System.Collections.Generic;

namespace ComProvis.Csp.Infrastructure.MS.Entities.GetSubscriptionResourceUsageResponse
{
    public class Attributes
    {
        public string objectType { get; set; }
    }

    public class Item
    {
        public string category { get; set; }
        public string subcategory { get; set; }
        public double quantityUsed { get; set; }
        public string unit { get; set; }
        public Guid id { get; set; }
        public string name { get; set; }
        public double totalCost { get; set; }
        public string currencyLocale { get; set; }
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

    public class GetSubscriptionResourceUsageResponse
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
        public Links links { get; set; }
        public Attributes2 attributes { get; set; }
    }
}
