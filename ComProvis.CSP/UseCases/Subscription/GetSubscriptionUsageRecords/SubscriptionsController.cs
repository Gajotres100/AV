using ComProvis.CSP.Application.UseCases.Subscription.Queries.GetSubscriptionResourceUsage;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.UseCases.Subscription.GetSubscriptionUsageRecords
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
        [Route("Usagerecords")]
        public async Task<IActionResult> GetAsync(Guid tenantId) => Ok(await _messages.DispatchAsync(new GetSubscriptionUsageRecordsUseCase(tenantId)));
    }
}
