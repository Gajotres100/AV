using System;
using System.Collections.Generic;

namespace ComProvis.CSP.Domain.Invoices
{
    public class Invoice : IEntity
    {
        public Guid Id { get; set; }
        public string InvoiceId { get; set; }
        public double TotalCharges { get; set; }
        public double PaidAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<string> InvoiceDetailLinks { get; set; }
        
    }
}
