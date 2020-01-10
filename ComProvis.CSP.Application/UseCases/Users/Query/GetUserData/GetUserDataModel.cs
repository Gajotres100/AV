using System;

namespace ComProvis.CSP.Application.UseCases.Users.Query.GetUserData
{
    public class GetUserDataModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int RoleId { get; set; }
    }
}