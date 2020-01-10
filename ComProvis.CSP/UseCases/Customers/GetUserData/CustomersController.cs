using ComProvis.CSP.Application.UseCases.Users.Query.GetUserData;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Customers.GetUserData
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

        [Authorize]
        [HttpGet()]
        [Route("Userdata")]
        public async Task<IActionResult> GetAsync() => Ok(await _messages.DispatchAsync(new GetUserDataUseCase()));
    }
}
