using ComProvis.CSP.Application.UseCases.Users.Query;
using ComProvis.CSP.Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace ComProvis.Csp.API.Authorization.GetMsCustomerDetails
{
    public class MustBeOwner : AuthorizationHandler<MustBeOwnerRequirement>
    {
        private readonly IMessages _messages;
        public MustBeOwner(IMessages messages)
        {
            _messages = messages;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MustBeOwnerRequirement requirement)
        {
            var filterContext = context.Resource as AuthorizationFilterContext;
            if (filterContext == null || context.User.Claims.FirstOrDefault()?.Value == null)
            {
                context.Fail();
                return;
            }

            var tenantId = filterContext.RouteData?.Values["tenantId"]?.ToString();
            var username = context.User.Claims.FirstOrDefault(c => c.Type.Contains("upn")).Value;

            if (string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(username))
            {
                context.Fail();
                return;
            }

            var user = await _messages.DispatchAsync(new GetUserByUsernameUseCase(username));

            if (user?.RoleId == (int)CSP.Common.Enums.Roles.Azure)
            {
                context.Succeed(requirement);
                return;
            }

            if(user == null || !user.CustomerId.Equals(tenantId))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
