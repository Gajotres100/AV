using System.Threading.Tasks;
using ComProvis.CSP.Application.Interfaces;

namespace ComProvis.CSP.Application.Utils
{
    public interface IMessages
    {
        Task DispatchAsync(ICommand command);
        Task<T> DispatchAsync<T>(IQuery<T> query);
    }
}