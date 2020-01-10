using System;
using System.Collections.Generic;

namespace ComProvis.Csp.Infrastructure.MS.Entities.GetInvoiceLineItems
{
    public class Attributes
    {
        public string objectType { get; set; }
    }

    public class Item
    {
        public string partnerId { get; set; }
        public string customerId { get; set; }
        public string customerName { get; set; }
        public int mpnId { get; set; }
        public int tier2MpnId { get; set; }
        public string orderId { get; set; }
        public string subscriptionId { get; set; }
        public string syndicationPartnerSubscriptionNumber { get; set; }
        public string offerId { get; set; }
        public string durableOfferId { get; set; }
        public string offerName { get; set; }
        public string domainName { get; set; }
        public string billingCycleType { get; set; }
        public string subscriptionName { get; set; }
        public string subscriptionDescription { get; set; }
        public DateTime subscriptionStartDate { get; set; }
        public DateTime subscriptionEndDate { get; set; }
        public DateTime chargeStartDate { get; set; }
        public DateTime chargeEndDate { get; set; }
        public string chargeType { get; set; }
        public double unitPrice { get; set; }
        public int quantity { get; set; }
        public double amount { get; set; }
        public double totalOtherDiscount { get; set; }
        public double subtotal { get; set; }
        public double tax { get; set; }
        public double totalForCustomer { get; set; }
        public string currency { get; set; }
        public string invoiceLineItemType { get; set; }
        public string billingProvider { get; set; }
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

    public class GetOfficeInvoiceLineItems
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
        public Links links { get; set; }
        public Attributes2 attributes { get; set; }
    }
}
