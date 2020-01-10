using Microsoft.AspNetCore.Authorization;

namespace ComProvis.Csp.API.Authorization.GetMsCustomerDetails
{
    public class MustBeOwnerRequirement : IAuthorizationRequirement
    {
        public MustBeOwnerRequirement()
        {
        }
    }
}