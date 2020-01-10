using ComProvis.CSP.Application.Interfaces;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetInvoiceById
{
    public class GetPagedInvoicesByIdUseCase : IQuery<GetPagedInvoicesLineItemModel>
    {
        internal string InvoiceId { get; }
        public GetPagedInvoicesByIdUseCase(string invoiceId)
        {
            InvoiceId = invoiceId;
        }

    }

    internal class GetPagedInvoiceByIdHandler : IQueryHandler<GetPagedInvoicesByIdUseCase, GetPagedInvoicesLineItemModel>
    {
        ICspClient CspClient { get; set; }
        public GetPagedInvoiceByIdHandler(ICspClient cspClient)
        {
            CspClient = cspClient;
        }

        public async Task<GetPagedInvoicesLineItemModel> HandleAsync(GetPagedInvoicesByIdUseCase data)
        {
            var invoiceItems = await CspClient.GetInvoiceByIdAsync(data.InvoiceId);

            return new GetPagedInvoicesLineItemModel
            {

            };
        }
    }
}
