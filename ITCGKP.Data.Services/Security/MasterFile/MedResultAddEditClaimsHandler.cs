using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.Security.MasterFile
{
    public class MedResultManageClaimsRequirement : IAuthorizationRequirement
    {
    }
    public class MedResultAddEditClaimsHandler :
        AuthorizationHandler<MedResultManageClaimsRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MedResultAddEditClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MedResultManageClaimsRequirement requirement)
        {
            int agentId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.Query["id"]);
            if (agentId == 0)
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Medical Result" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            else
            {
                if (context.User.IsInRole("User") &&
                    context.User.HasClaim(claim => claim.Type == "Medical Result" && claim.Value == "true"))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
    public class MedResultOtherUserHandler :
      AuthorizationHandler<MedResultManageClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MedResultManageClaimsRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
