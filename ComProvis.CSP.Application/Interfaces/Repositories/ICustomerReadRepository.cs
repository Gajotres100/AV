using ComProvis.CSP.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace omProvis.CSP.Application.Interfaces.Repository
{
    public interface ICustomerReadRepository
    {
        Task<Customer> Get(Guid id);
    }
}