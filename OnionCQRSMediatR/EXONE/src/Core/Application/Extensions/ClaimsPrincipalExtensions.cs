using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal principal, string claimType)
        {
            List<string>? result = principal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string>? ClaimsRoles(this ClaimsPrincipal principal)
        {
            return principal?.Claims(ClaimTypes.Role);
        }

        public static int GetUserId(this ClaimsPrincipal principal)
        {
            return Convert.ToInt32(principal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
        }
    }
}
