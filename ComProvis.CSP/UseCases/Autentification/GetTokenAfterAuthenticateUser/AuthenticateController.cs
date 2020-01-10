using ComProvis.CSP.Application.UseCases.Autentification.Queries;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Autentification.GetTokenAfterAuthenticateUser
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMessages _messages;
        public AuthenticateController(IMessages messages)
        {
            _messages = messages;
        }

        [HttpGet()]
        [Route("{username}/password/{password}")]
        public async Task<IActionResult> GetAsync(string username, string password)
        {
            var token = await _messages.DispatchAsync(new GetTokenAfterAuthenticateUserUseCase(username, password));
            //if(token == null) return StatusCode(403);
            return Ok(new { token?.Token });
        }

    }
}
