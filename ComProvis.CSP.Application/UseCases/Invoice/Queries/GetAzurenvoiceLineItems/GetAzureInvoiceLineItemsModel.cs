using System;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetAzurenvoiceLineItems
{
    public class GetAzureInvoiceLineItemsModel
    {
        public string PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerBillableAccountId { get; set; }
        public object CustomerCompanyName { get; set; }
        public int MpnId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime ChargeStartDate { get; set; }
        public DateTime ChargeEndDate { get; set; }
        public string SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionDescription { get; set; }
        public string OrderId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public string ResourceGuid { get; set; }
        public string ResourceName { get; set; }
        public string Region { get; set; }
        public string Sku { get; set; }
        public int DetailLineItemId { get; set; }
        public double ConsumedQuantity { get; set; }
        public double IncludedQuantity { get; set; }
        public double OverageQuantity { get; set; }
        public double ListPrice { get; set; }
        public double PretaxCharges { get; set; }
        public double TaxAmount { get; set; }
        public double PostTaxTotal { get; set; }
        public string Currency { get; set; }
        public double PretaxEffectiveRate { get; set; }
        public double PostTaxEffectiveRate { get; set; }
        public string ChargeType { get; set; }
        public string CustomerId { get; set; }
        public string DomainName { get; set; }
        public string BillingCycleType { get; set; }
        public string Unit { get; set; }
    }
}