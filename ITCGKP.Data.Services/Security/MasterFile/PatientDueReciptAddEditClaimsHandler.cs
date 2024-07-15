using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.MasterFile
{
    public class PatientDueReciptManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class PatientDueReciptAddEditClaimsHandler :
        AuthorizationHandler<PatientDueReciptManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PatientDueReciptAddEditClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PatientDueReciptManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Create Patient Due Receipt" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            else
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Edit Patient Due Receipt" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
    public class PatientDueReciptOtherUserHandler :
      AuthorizationHandler<PatientDueReciptManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PatientDueReciptManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    // Delete 
    public class PatientDueReciptDeleteManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class PatientDueReciptDeleteClaimsHandler :
        AuthorizationHandler<PatientDueReciptDeleteManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PatientDueReciptDeleteClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PatientDueReciptDeleteManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                   context.User.HasClaim(claim => claim.Type == "Delete Patient Due Receipt" && claim.Value == "true")
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
                    context.User.HasClaim(claim => claim.Type == "Delete Patient Due Receipt" && claim.Value == "true")
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