using AutoMapper;
using ComProvis.CSP.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetAzurenvoiceLineItems
{
    public class GetAzureInvoiceLineItemsUseCase : IQuery<List<GetAzureInvoiceLineItemsModel>>
    {
        internal string InvoiceId { get; }
        public GetAzureInvoiceLineItemsUseCase(string invoiceId)
        {
            InvoiceId = invoiceId;
        }

        internal class GetAzureInvoiceLineItemsHandler : IQueryHandler<GetAzureInvoiceLineItemsUseCase, List<GetAzureInvoiceLineItemsModel>>
        {
            ICspClient CspClient { get; set; }
            IMapper Mapper { get; set; }
            public GetAzureInvoiceLineItemsHandler(ICspClient cspClient, IMapper mapper)
            {
                CspClient = cspClient;
                Mapper = mapper;
            }

            public async Task<List<GetAzureInvoiceLineItemsModel>> HandleAsync(GetAzureInvoiceLineItemsUseCase data)
            {
                var invoiceItems = await CspClient.GetInvoiceByIdAsync(data.InvoiceId);

                var link = invoiceItems.InvoiceDetailLinks.FirstOrDefault(x => x.Contains($"{nameof(Common.Enums.BillingProvider.Azure)}/BillingLineItems"));

                if (string.IsNullOrEmpty(link)) return null;

                return Mapper.Map<List<GetAzureInvoiceLineItemsModel>>(await CspClient.GetAzureInvoiceLineItemsAsync(link));

            }
        }
    }
}
