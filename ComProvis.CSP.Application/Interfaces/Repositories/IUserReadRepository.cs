using ComProvis.CSP.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.Interfaces.Repositories
{
    public interface IUserReadRepository
    {
        Task<User> Get(Guid id);
        Task<User> GetByUsername(string username);
        Task<User> GetFirstByCustomerId(Guid customerId);
        Task<User> AuteticateUser(string username, string password);
    }
}
