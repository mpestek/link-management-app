using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Validators.Interfaces
{
    public interface IUriValidator
    {
        bool isValid(string uri);
    }
}
