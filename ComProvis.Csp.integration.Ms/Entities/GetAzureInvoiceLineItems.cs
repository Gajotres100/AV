using System;
using System.Collections.Generic;

namespace ComProvis.Csp.Infrastructure.MS.Entities.GetAzureInvoiceLineItems
{
    public class Attributes
    {
        public string objectType { get; set; }
    }

    public class Item
    {
        public int detailLineItemId { get; set; }
        public string sku { get; set; }
        public double includedQuantity { get; set; }
        public double overageQuantity { get; set; }
        public double listPrice { get; set; }
        public string currency { get; set; }
        public double pretaxCharges { get; set; }
        public double taxAmount { get; set; }
        public double postTaxTotal { get; set; }
        public double pretaxEffectiveRate { get; set; }
        public double postTaxEffectiveRate { get; set; }
        public string chargeType { get; set; }
        public string invoiceLineItemType { get; set; }
        public string partnerId { get; set; }
        public string partnerName { get; set; }
        public string partnerBillableAccountId { get; set; }
        public string customerId { get; set; }
        public string domainName { get; set; }
        public string customerCompanyName { get; set; }
        public int mpnId { get; set; }
        public int tier2MpnId { get; set; }
        public string invoiceNumber { get; set; }
        public string subscriptionId { get; set; }
        public string subscriptionName { get; set; }
        public string subscriptionDescription { get; set; }
        public string billingCycleType { get; set; }
        public string orderId { get; set; }
        public string serviceName { get; set; }
        public string serviceType { get; set; }
        public string resourceGuid { get; set; }
        public string resourceName { get; set; }
        public string region { get; set; }
        public double consumedQuantity { get; set; }
        public DateTime chargeStartDate { get; set; }
        public DateTime chargeEndDate { get; set; }
        public string unit { get; set; }
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

    public class GetAzureInvoiceLineItems
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
        public Links links { get; set; }
        public Attributes2 attributes { get; set; }
    }
}
