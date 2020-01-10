using System;

namespace ComProvis.CSP.Application.Customers.Queries.GetCustomersFromMsGraf
{
    public class GetCustomersModel
    {
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        public string DomainName { get; set; }


    }
}
