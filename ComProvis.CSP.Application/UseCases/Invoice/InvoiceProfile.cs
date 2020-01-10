using AutoMapper;
using ComProvis.CSP.Application.UseCases.Invoice.Queries.GetAzurenvoiceLineItems;
using ComProvis.CSP.Application.UseCases.Invoice.Queries.GetCustomersAzurenvoiceLineItems;
using ComProvis.CSP.Application.UseCases.Invoice.Queries.GetCustomersOfficeLineItems;
using ComProvis.CSP.Application.UseCases.Invoice.Queries.GetInvoiceLineItems;
using ComProvis.CSP.Domain.Invoices;

namespace ComProvis.CSP.Application.UseCases.Invoice
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<OfficeInvoiceLineItem, GetOfficeInvoiceLineItemsModel>();
            CreateMap<AzureInvoiceLineItem, GetAzureInvoiceLineItemsModel>();
            CreateMap<OfficeInvoiceLineItem, GetCustomersOfficeInvoiceLineItemsModel>();
            CreateMap<AzureInvoiceLineItem, GetCustomersAzureInvoiceLineItemsModel>();
        }
    }
}
