using System.Collections.Generic;

namespace ComProvis.Csp.Infrastructure.MS.Entities.GetCustomerResponse
{
    public class Address
    {
        public string country { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string addressLine1 { get; set; }
        public string postalCode { get; set; }
        public string phoneNumber { get; set; }
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

    public class Attributes
    {
        public string objectType { get; set; }
    }

    public class CompanyProfile
    {
        public string tenantId { get; set; }
        public string domain { get; set; }
        public string companyName { get; set; }
        public Address address { get; set; }
        public string email { get; set; }
        public Links links { get; set; }
        public Attributes attributes { get; set; }
    }

    public class DefaultAddress
    {
        public string country { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string addressLine1 { get; set; }
        public string postalCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
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
        public string etag { get; set; }
        public string objectType { get; set; }
    }

    public class BillingProfile
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string culture { get; set; }
        public string language { get; set; }
        public string companyName { get; set; }
        public DefaultAddress defaultAddress { get; set; }
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

    public class GetCustomerResponse
    {
        public string id { get; set; }
        public string commerceId { get; set; }
        public CompanyProfile companyProfile { get; set; }
        public BillingProfile billingProfile { get; set; }
        public string relationshipToPartner { get; set; }
        public bool allowDelegatedAccess { get; set; }
        public List<string> customDomains { get; set; }
        public Links3 links { get; set; }
        public Attributes3 attributes { get; set; }
    }
}
