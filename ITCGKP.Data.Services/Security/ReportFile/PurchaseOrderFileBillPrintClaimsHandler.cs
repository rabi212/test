using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.ReportFile
{
    public class PurchaseOrderFileBillPrintManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class PurchaseOrderFileBillPrintClaimsHandler :
        AuthorizationHandler<PurchaseOrderFileBillPrintManageClaimsRequirement>
    {        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PurchaseOrderFileBillPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("User") &&
                context.User.HasClaim(claim => claim.Type == "Order Bill Print" && claim.Value == "true"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
    public class PurchaseOrderFileBillPrintOtherUserHandler :
      AuthorizationHandler<PurchaseOrderFileBillPrintManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PurchaseOrderFileBillPrintManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin") || context.User.IsInRole("Admin") || context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}