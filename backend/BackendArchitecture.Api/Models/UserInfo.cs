using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Username { get; set; }

        public List<string> Roles { get; set; }
    }
}
