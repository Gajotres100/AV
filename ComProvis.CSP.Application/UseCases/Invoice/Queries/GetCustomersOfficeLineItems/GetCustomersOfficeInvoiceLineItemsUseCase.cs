using AutoMapper;
using ComProvis.CSP.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetCustomersOfficeLineItems
{
    public class GetCustomersOfficeInvoiceLineItemsUseCase : IQuery<List<GetCustomersOfficeInvoiceLineItemsModel>>
    {
        internal string InvoiceId { get; }
        internal string TenantId { get; }
        public GetCustomersOfficeInvoiceLineItemsUseCase(string invoiceId, string tenantId)
        {
            InvoiceId = invoiceId;
            TenantId = tenantId;
        }

        internal class GetCustomersOfficeInvoiceLineItemsHandler : IQueryHandler<GetCustomersOfficeInvoiceLineItemsUseCase, List<GetCustomersOfficeInvoiceLineItemsModel>>
        {
            ICspClient CspClient { get; set; }
            IMapper Mapper { get; set; }
            public GetCustomersOfficeInvoiceLineItemsHandler(ICspClient cspClient, IMapper mapper)
            {
                CspClient = cspClient;
                Mapper = mapper;
            }

            public async Task<List<GetCustomersOfficeInvoiceLineItemsModel>> HandleAsync(GetCustomersOfficeInvoiceLineItemsUseCase data)
            {
                var invoiceItems = await CspClient.GetInvoiceByIdAsync(data.InvoiceId);

                var link = invoiceItems.InvoiceDetailLinks.FirstOrDefault(x => x.Contains($"{nameof(Common.Enums.BillingProvider.Office)}/BillingLineItems"));

                if (string.IsNullOrEmpty(link)) return null;

                var lineItems = await CspClient.GetOfficeInvoiceLineItemsAsync(link);

                return Mapper.Map<List<GetCustomersOfficeInvoiceLineItemsModel>>(lineItems.Where(x => x.CustomerId.Equals(data.TenantId)));

            }
        }
    }
}
