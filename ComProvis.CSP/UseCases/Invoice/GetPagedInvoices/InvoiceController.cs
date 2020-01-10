using ComProvis.CSP.Application.UseCases.Invoice.Queries.GetPagedInvoices;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Invoice.GetPagedInvoices
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
        [Route("")]
        public async Task<IActionResult> GetAsync() => Ok(await _messages.DispatchAsync(new GetPagedInvoicesUseCase()));
    }
}
