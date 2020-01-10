using ComProvis.CSP.Application.UseCases.Customers.Commands.ChangePassword;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Customers.ChangePassword
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
        [Route("{TenantId}/ChangePassword")]
        public async Task<IActionResult> PostAsync([FromRoute]ChangePasswordModel data)
        {
            await _messages.DispatchAsync(new ChangePasswordCommand(data));
            return Ok(data);
        }
    }
}
