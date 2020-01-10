using ComProvis.CSP.Application.UseCases.Customers.Queries.GetMsCustomerDetails;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace ComProvis.Csp.API.UseCases.Customers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMessages _messages;

        public CustomersController(IMessages messages)
        {
            _messages = messages;
        }

        [HttpGet()]
        [Route("{tenantId:guid}")]
        public async Task<IActionResult> GetAsync([FromRoute]Guid tenantId) => Ok(await _messages.DispatchAsync(new GetCustomerFromMsGraf(tenantId)));
    }
}
