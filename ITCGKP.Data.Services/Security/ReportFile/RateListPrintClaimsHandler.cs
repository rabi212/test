using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.ReportFile
{
    public class RateListPrintManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class RateListPrintClaimsHandler :
        AuthorizationHandler<RateListPrintManageClaimsRequirement>
    {        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RateListPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("User") &&
                context.User.HasClaim(claim => claim.Type == "Rate List" && claim.Value == "true"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
    public class RateListPrintOtherUserHandler :
      AuthorizationHandler<RateListPrintManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RateListPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}