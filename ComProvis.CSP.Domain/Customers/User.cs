using System;

namespace ComProvis.CSP.Domain.Customers
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}

