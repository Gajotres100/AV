using System;
using System.Collections.Generic;

namespace ComProvis.CSP.Persistance.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public decimal? Margin { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}