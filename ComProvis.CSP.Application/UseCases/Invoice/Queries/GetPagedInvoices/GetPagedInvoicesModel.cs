using System;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetPagedInvoices
{
    public class GetPagedInvoicesModel
    {
        public string Id { get; set; }
        public double TotalCharges { get; set; }
        public double PaidAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
