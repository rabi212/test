using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.MasterFile
{
    public class TestManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class TestAddEditClaimsHandler :
        AuthorizationHandler<TestManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TestAddEditClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Create Test Master" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            else
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Edit Test Master" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
    public class TestOtherUserHandler :
      AuthorizationHandler<TestManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    // Delete 
    public class TestDeleteManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class TestDeleteClaimsHandler :
        AuthorizationHandler<TestDeleteManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TestDeleteClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestDeleteManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                   context.User.HasClaim(claim => claim.Type == "Delete Test Master" && claim.Value == "true")
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
                    context.User.HasClaim(claim => claim.Type == "Delete Test Master" && claim.Value == "true")
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
