using ComProvis.CSP.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.Interfaces.Repositories
{
    public interface IUserWriteRepository
    {
        Task Add(User user);
        Task Delete(Guid id);
        Task Update(User customer);
    }
}
