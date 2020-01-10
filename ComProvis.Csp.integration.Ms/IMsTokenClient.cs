using System.Threading.Tasks;
using ComProvis.Csp.Infrastructure.MS.Entities;

namespace ComProvis.Csp.Infrastructure.MS
{
    public interface IMsTokenClient
    {
        Task<GetTokenResponse> GetTokenAsync();
    }
}