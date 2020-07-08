using BackendArchitecture.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Helpers
{
    public class UserUtilities : IUserUtilities
    {
        public UserInfo GetUserInfo(ClaimsPrincipal userPrincipal)
        {
            if (userPrincipal == null)
            {
                throw new ArgumentException("User cannot be unknown.");
            }

            return new UserInfo()
            {
                Id = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier),
                Username = userPrincipal.FindFirstValue(ClaimTypes.Name),
                Roles = userPrincipal.FindAll(ClaimTypes.Role)
                                     .Select(roleClaim => roleClaim.Value)
                                     .ToList()
            };
        }
    }
}
