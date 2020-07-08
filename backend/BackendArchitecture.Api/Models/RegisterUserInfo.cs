using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Models
{
    public class RegisterUserInfo
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
