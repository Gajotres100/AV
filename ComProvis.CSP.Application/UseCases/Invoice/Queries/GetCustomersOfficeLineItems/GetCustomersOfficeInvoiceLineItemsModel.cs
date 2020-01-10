using System;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetCustomersOfficeLineItems
{
    public class GetCustomersOfficeInvoiceLineItemsModel
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OfferName { get; set; }
        public double TotalForCustomer { get; set; }
        public double Subtotal { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string PartnerId { get; set; }
        public int MpnId { get; set; }
        public string DomainName { get; set; }
        public string BillingCycleType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public DateTime ChargeStartDate { get; set; }
        public DateTime ChargeEndDate { get; set; }
        public double Tax { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionId { get; set; }
        public string SyndicationPartnerSubscriptionNumber { get; set; }
        public string OfferId { get; set; }
        public string OrderId { get; set; }
        public string DurableOfferId { get; set; }
        public double Amount { get; set; }
        public double TotalOtherDiscount { get; set; }
        public string Currency { get; set; }
        public string SubscriptionDescription { get; set; }


    }
}