using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RestaurantReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantReservation.Services.Factories
{
    public class RRUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<RRUser, IdentityRole>
    {
        public RRUserClaimsPrincipalFactory(
            UserManager<RRUser> userManager, RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) :
            base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(RRUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("ReservationId", user.ReservationId.ToString()));

            return identity;
        }
    }
}
