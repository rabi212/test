using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.ReportFile
{
    public class MonthlyBankStatementPrintManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class MonthlyBankStatementPrintClaimsHandler :
        AuthorizationHandler<MonthlyBankStatementPrintManageClaimsRequirement>
    {        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MonthlyBankStatementPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("User") &&
                context.User.HasClaim(claim => claim.Type == "Monthly Salary Bank Statement" && claim.Value == "true"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
    public class MonthlyBankStatementPrintOtherUserHandler :
      AuthorizationHandler<MonthlyBankStatementPrintManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MonthlyBankStatementPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}