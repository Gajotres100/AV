using System;

namespace ComProvis.CSP.Application.UseCases.Users.Query
{
    public class GetUserModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int RoleId { get; set; }
    }
}