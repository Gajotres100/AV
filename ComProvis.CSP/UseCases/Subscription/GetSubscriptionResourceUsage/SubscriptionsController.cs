using ComProvis.CSP.Application.UseCases.Subscription.Queries.GetSubscriptionResourceUsage;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Subscription.GetSubscriptionResourceUsage
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
        [Route("{subscrptionId}/ResourceUsage")]
        public async Task<IActionResult> GetAsync(Guid tenantId, string subscrptionId) => Ok(await _messages.DispatchAsync(new GetSubscriptionResourceUsageUseCase(tenantId, subscrptionId)));
    }
}
