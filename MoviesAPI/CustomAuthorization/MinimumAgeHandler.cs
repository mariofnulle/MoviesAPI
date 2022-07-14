using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoviesAPI.CustomAuthorization
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(claim => claim.Type == ClaimTypes.DateOfBirth))
                return Task.CompletedTask;

            DateTime birthDate = Convert.ToDateTime(context.User.FindFirst(user => user.Type == ClaimTypes.DateOfBirth).Value);

            int getDate = DateTime.Now.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-getDate))
                getDate --;

            if (getDate >= requirement.MinimumAge)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
