using Microsoft.AspNetCore.Mvc;
using System;
using FluentValidation;

namespace ComProvis.CSP.Application.UseCases.Customers.Commands.ChangePassword
{
    public class ChangePasswordModel : BaseModel
    {
        [FromRoute(Name = "TenantId")] public Guid TenantId { get; set; }

        public class BodyData
        {
            [FromBody] public string Username { get; set; }
            [FromBody] public string Password { get; set; }
        }

        [FromBody] public BodyData Data { get; set; }
    }

    public class RegisterCustomerModelValidator : AbstractValidator<ChangePasswordModel>
    {

        public RegisterCustomerModelValidator() : base()
        {
            RuleFor(x => x.TenantId)
                 .NotNull().WithMessage("{PropertyName} must be provided");
            RuleFor(x => x.Data.Username)
                 .NotNull().WithMessage("{PropertyName} must be provided");
            RuleFor(x => x.Data.Password)
                 .NotNull().WithMessage("{PropertyName} must be provided");
        }
    }
}
