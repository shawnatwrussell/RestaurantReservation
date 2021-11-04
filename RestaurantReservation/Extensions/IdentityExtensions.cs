using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace RestaurantReservation.Extensions
{
    public static class IdentityExtensions
    {
        public static int? GetRestaurantId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("RestaurantId");
            return (claim != null) ? int.Parse(claim.Value) : null;
        }

    }
}
