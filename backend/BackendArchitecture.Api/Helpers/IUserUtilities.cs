using BackendArchitecture.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Helpers
{
    public interface IUserUtilities
    {
        UserInfo GetUserInfo(ClaimsPrincipal userPrincipal);
    }
}
