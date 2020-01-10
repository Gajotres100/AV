using System.Threading.Tasks;
using ComProvis.CSP.Application.Customers.Queries.GetCustomersFromMsGraf;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ComProvis.Csp.API.UseCases.Customers.GetMsCustomerList
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
        [Route("")]
        public async Task<IActionResult> GetAsync() => Ok(await _messages.DispatchAsync(new GetCustomersFromMsGrafUseCase()));
    }
}