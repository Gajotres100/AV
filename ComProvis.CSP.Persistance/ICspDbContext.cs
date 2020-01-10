using ComProvis.CSP.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComProvis.CSP.Persistance
{
    public interface ICspDbContext
    {
        DbSet<Customer> Customer { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        Task SaveChangesAsync();
    }
}
