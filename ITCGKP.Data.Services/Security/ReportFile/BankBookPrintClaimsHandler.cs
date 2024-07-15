using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.ReportFile
{
    public class BankBookPrintManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class BankBookPrintClaimsHandler :
        AuthorizationHandler<BankBookPrintManageClaimsRequirement>
    {        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BankBookPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("User") &&
                context.User.HasClaim(claim => claim.Type == "Bank Book Print" && claim.Value == "true"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
    public class BankBookPrintOtherUserHandler :
      AuthorizationHandler<BankBookPrintManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BankBookPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}