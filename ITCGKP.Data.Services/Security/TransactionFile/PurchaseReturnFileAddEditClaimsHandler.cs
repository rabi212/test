using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.TransactionFile
{
    public class PurchaseReturnFileManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class PurchaseReturnFileAddEditClaimsHandler :
        AuthorizationHandler<PurchaseReturnFileManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PurchaseReturnFileAddEditClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PurchaseReturnFileManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Create Debit Note File" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            else
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Edit Debit Note File" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
    public class PurchaseReturnFileOtherUserHandler :
      AuthorizationHandler<PurchaseReturnFileManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PurchaseReturnFileManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    // Delete 
    public class PurchaseReturnFileDeleteManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class PurchaseReturnFileDeleteClaimsHandler :
        AuthorizationHandler<PurchaseReturnFileDeleteManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PurchaseReturnFileDeleteClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PurchaseReturnFileDeleteManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Delete Debit Note File" && claim.Value == "true")
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
                    context.User.HasClaim(claim => claim.Type == "Delete Debit Note File" && claim.Value == "true")
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