using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ClaimSample.Core.Security
{
  public static  class IdentityExtensions
    {
        public static string GetEmail(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Email);

            return claim?.Value ?? string.Empty;
        }


        public static string GetLastLogin(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            return claim?.Value ?? string.Empty;
        }

    }
}
