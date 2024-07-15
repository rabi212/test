using ITCGKP.Data.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.ProvideService
{
    public interface IUserService
    {
        Task<string> GetUserId();
        Task<bool> isAuthenticatedUser();
        Task<ClaimsPrincipal> GetClaimsPrincipalAsync();
    }
}