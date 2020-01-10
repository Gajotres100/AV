using AutoMapper;
using ComProvis.CSP.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetInvoiceLineItems
{
    public class GetOfficeInvoiceLineItemsUseCase : IQuery<List<GetOfficeInvoiceLineItemsModel>>
    {
        internal string InvoiceId { get; }
        public GetOfficeInvoiceLineItemsUseCase(string invoiceId)
        {
            InvoiceId = invoiceId;
        }

        internal class GetOfficeInvoiceLineItemsHandler : IQueryHandler<GetOfficeInvoiceLineItemsUseCase, List<GetOfficeInvoiceLineItemsModel>>
        {
            ICspClient CspClient { get; set; }
            IMapper Mapper { get; set; }
            public GetOfficeInvoiceLineItemsHandler(ICspClient cspClient, IMapper mapper)
            {
                CspClient = cspClient;
                Mapper = mapper;
            }

            public async Task<List<GetOfficeInvoiceLineItemsModel>> HandleAsync(GetOfficeInvoiceLineItemsUseCase data)
            {
                var invoiceItems = await CspClient.GetInvoiceByIdAsync(data.InvoiceId);

                var link = invoiceItems.InvoiceDetailLinks.FirstOrDefault(x => x.Contains($"{nameof(Common.Enums.BillingProvider.Office)}/BillingLineItems"));

                if (string.IsNullOrEmpty(link)) return null;               

                return Mapper.Map<List<GetOfficeInvoiceLineItemsModel>>(await CspClient.GetOfficeInvoiceLineItemsAsync(link));
                
            }
        }
    }
}
