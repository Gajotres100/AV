using Microsoft.AspNetCore.Mvc;
using System;

namespace ComProvis.CSP.Application.UseCases.Customers.Commands.ChangeMargin
{
    public class ChangeMarginModel
    {
        [FromRoute(Name = "TenantId")] public Guid TenantId { get; set; }

        public class BodyData
        {
            [FromBody] public decimal Margin { get; set; }
        }

        [FromBody] public BodyData Data { get; set; }
    }
}
