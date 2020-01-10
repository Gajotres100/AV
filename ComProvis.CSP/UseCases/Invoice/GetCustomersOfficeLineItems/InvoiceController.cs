using ComProvis.CSP.Application.UseCases.Invoice.Queries.GetCustomersOfficeLineItems;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Invoice.GetCustomersOfficeLineItems
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
        [Route("{invoiceId}/Officelineitems/{tenantId}")]
        public async Task<IActionResult> GetAsync(string invoiceId, string tenantId) => Ok(await _messages.DispatchAsync(new GetCustomersOfficeInvoiceLineItemsUseCase(invoiceId, tenantId)));
    }
}
