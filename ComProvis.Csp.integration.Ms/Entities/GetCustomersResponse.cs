using System;
using System.Collections.Generic;

namespace ComProvis.Csp.Infrastructure.MS.Entities.GetCustomersResponse
{
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

    public class Attributes
    {
        public string objectType { get; set; }
    }

    public class CompanyProfile
    {
        public Guid? tenantId { get; set; }
        public string domain { get; set; }
        public string companyName { get; set; }
        public Links links { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Self2
    {
        public string uri { get; set; }
        public string method { get; set; }
        public List<object> headers { get; set; }
    }

    public class Links2
    {
        public Self2 self { get; set; }
    }

    public class Attributes2
    {
        public string objectType { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public CompanyProfile companyProfile { get; set; }
        public string relationshipToPartner { get; set; }
        public Links2 links { get; set; }
        public Attributes2 attributes { get; set; }
    }

    public class Self3
    {
        public string uri { get; set; }
        public string method { get; set; }
        public List<object> headers { get; set; }
    }

    public class Links3
    {
        public Self3 self { get; set; }
    }

    public class Attributes3
    {
        public string objectType { get; set; }
    }

    public class GetCustomersResponse
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
        public Links3 links { get; set; }
        public Attributes3 attributes { get; set; }
    }
}
