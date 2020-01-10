namespace ComProvis.CSP.Application.UseCases.Customers.Queries.GetMsCustomerDetails
{
    public class GetCustomerModel
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }       
        public string City { get; set; }      
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? Margin { get; set; }

    }

    
}