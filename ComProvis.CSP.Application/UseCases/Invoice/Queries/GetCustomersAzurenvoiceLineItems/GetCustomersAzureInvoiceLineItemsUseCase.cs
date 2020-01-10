using AutoMapper;
using ComProvis.CSP.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetCustomersAzurenvoiceLineItems
{
    public class GetCustomersAzureInvoiceLineItemsUseCase : IQuery<List<GetCustomersAzureInvoiceLineItemsModel>>
    {
        internal string InvoiceId { get; }
        internal string TenantId { get; }
        public GetCustomersAzureInvoiceLineItemsUseCase(string invoiceId, string tenantId)
        {
            InvoiceId = invoiceId;
            TenantId = tenantId;
        }

        internal class GetCustomersAzureInvoiceLineItemsHandler : IQueryHandler<GetCustomersAzureInvoiceLineItemsUseCase, List<GetCustomersAzureInvoiceLineItemsModel>>
        {
            ICspClient CspClient { get; set; }
            IMapper Mapper { get; set; }
            public GetCustomersAzureInvoiceLineItemsHandler(ICspClient cspClient, IMapper mapper)
            {
                CspClient = cspClient;
                Mapper = mapper;
            }

            public async Task<List<GetCustomersAzureInvoiceLineItemsModel>> HandleAsync(GetCustomersAzureInvoiceLineItemsUseCase data)
            {
                var invoiceItems = await CspClient.GetInvoiceByIdAsync(data.InvoiceId);

                var link = invoiceItems.InvoiceDetailLinks.FirstOrDefault(x => x.Contains($"{nameof(Common.Enums.BillingProvider.Azure)}/BillingLineItems"));

                if (string.IsNullOrEmpty(link)) return null;

                var lineItems = await CspClient.GetAzureInvoiceLineItemsAsync(link);

                return Mapper.Map<List<GetCustomersAzureInvoiceLineItemsModel>>(lineItems.Where(x=> x.CustomerId.Equals(data.TenantId)));

            }
        }
    }
}
