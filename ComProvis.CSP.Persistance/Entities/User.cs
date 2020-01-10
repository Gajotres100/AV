using System;

namespace ComProvis.CSP.Persistance.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Role Role { get; set; }
    }
}