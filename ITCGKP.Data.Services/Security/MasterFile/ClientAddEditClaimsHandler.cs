using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.MasterFile
{
    public class ClientManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class ClientAddEditClaimsHandler :
        AuthorizationHandler<ClientManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClientAddEditClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClientManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Create Client" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            else
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Edit Client" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
    public class ClientOtherUserHandler :
      AuthorizationHandler<ClientManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClientManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    // Delete 
    public class ClientDeleteManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class ClientDeleteClaimsHandler :
        AuthorizationHandler<ClientDeleteManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClientDeleteClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClientDeleteManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                   context.User.HasClaim(claim => claim.Type == "Delete Client" && claim.Value == "true")
                   || context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin")
                   || context.User.IsInRole("Manager"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    return Task.CompletedTask;
                }
            }
            else
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Delete Client" && claim.Value == "true")
                    || context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin")
                    || context.User.IsInRole("Manager"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
