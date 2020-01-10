using System;

namespace ComProvis.CSP.Domain.Customers
{
    public class Customer : IEntity
    {
        public Guid Id { get; set; }        
        public decimal? Margin { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Domain { get; set; }
        public string Name { get; set; }      
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }       


    }
}
