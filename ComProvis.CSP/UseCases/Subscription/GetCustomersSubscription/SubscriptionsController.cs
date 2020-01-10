using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ComProvis.CSP.Application.UseCases.Subscription.Queries.GetCustomersSubscription;
using System;

namespace ComProvis.Csp.API.UseCases.Subscription.GetCustomersSubscription
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Customers/{tenantId}/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMessages _messages;
        public SubscriptionsController(IMessages messages)
        {
            _messages = messages;
        }

        [HttpGet()]
        [Route("")]
        public async Task<IActionResult> GetAsync(Guid tenantId) => Ok(await _messages.DispatchAsync(new GetCustomersSubscriptionUseCases(tenantId)));
    }
}
