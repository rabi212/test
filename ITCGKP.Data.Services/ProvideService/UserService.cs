using ITCGKP.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.ProvideService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        { 
               _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetUserId()
        {
            return await Task.FromResult(_httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public async Task<bool> isAuthenticatedUser()
        {
            return await Task.FromResult(_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated);
        }       
        public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync()
        {
            return await Task.FromResult(_httpContextAccessor.HttpContext?.User);
        }      
    }
}
