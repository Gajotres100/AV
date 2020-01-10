using ComProvis.CSP.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.Interfaces.Repositories
{
    public interface ICustomerWriteRepository
    {
        Task Add(Customer customer);
        Task Delete(Guid id);
        Task Update(Customer customer);
    }
}
