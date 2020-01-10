using ComProvis.CSP.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.UseCases.Invoice.Queries.GetPagedInvoices
{
    public class GetPagedInvoicesUseCase : IQuery<List<GetPagedInvoicesModel>>
    {
        public GetPagedInvoicesUseCase()
        {

        }
    }

    internal class GetPagedInvoicesHandler : IQueryHandler<GetPagedInvoicesUseCase, List<GetPagedInvoicesModel>>
    {
        ICspClient CspClient { get; set; }
        public GetPagedInvoicesHandler(ICspClient cspClient)
        {
            CspClient = cspClient;
        }

        public async Task<List<GetPagedInvoicesModel>> HandleAsync(GetPagedInvoicesUseCase data)
        {
            var invoices = await CspClient.GetInvoicesAsync();

            return invoices?.Select(x => new GetPagedInvoicesModel
            {
                Id = x.InvoiceId,
                PaidAmount=x.PaidAmount,
                InvoiceDate=x.InvoiceDate,
                TotalCharges=x.TotalCharges
            }).ToList();
        }
    }
}
