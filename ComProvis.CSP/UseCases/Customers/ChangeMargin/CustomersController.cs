using ComProvis.CSP.Application.UseCases.Customers.Commands.ChangeMargin;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Customers.ChangeMargin
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

        [HttpPost()]
        [Route("{TenantId}/ChangeMargin")]
        public async Task<IActionResult> PostAsync([FromRoute]ChangeMarginModel data)
        {
            await _messages.DispatchAsync(new ChangeMarginCommand(data));
            return Ok(data);
        }
    }
}
