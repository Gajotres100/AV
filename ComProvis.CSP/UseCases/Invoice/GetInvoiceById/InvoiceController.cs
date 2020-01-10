using ComProvis.CSP.Application.UseCases.Invoice.Queries.GetInvoiceById;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Invoice.GetInvoicesLineItems
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IMessages _messages;

        public InvoiceController(IMessages messages)
        {
            _messages = messages;
        }

        [HttpGet()]
        [Route("{invoiceId}")]
        public async Task<IActionResult> GetAsync(string invoiceId) => Ok(await _messages.DispatchAsync(new GetPagedInvoicesByIdUseCase(invoiceId)));
    }
}
