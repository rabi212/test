using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.FinancialFile
{
    public class UnitMeasurementManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class UnitMeasurementAddEditClaimsHandler :
        AuthorizationHandler<UnitMeasurementManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitMeasurementAddEditClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UnitMeasurementManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Create Unit Measurement" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            else
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Edit Unit Measurement" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
    public class UnitMeasurementOtherUserHandler :
      AuthorizationHandler<UnitMeasurementManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UnitMeasurementManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    // Delete 
    public class UnitMeasurementDeleteManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class UnitMeasurementDeleteClaimsHandler :
        AuthorizationHandler<UnitMeasurementDeleteManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitMeasurementDeleteClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UnitMeasurementDeleteManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Delete Unit Measurement" && claim.Value == "true")
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
                    context.User.HasClaim(claim => claim.Type == "Delete Unit Measurement" && claim.Value == "true")
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