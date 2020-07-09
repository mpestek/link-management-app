using BackendArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Validators
{
    public static class LinkValidator
    {
        public static bool isValid(Link link)
        {
            return UriValidator.isValid(link.Uri) && link.Tags.Count > 0;
        }
    }
}
