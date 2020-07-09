using BackendArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Validators.Interfaces
{
    public interface ILinkValidator
    {
        bool isValid(Link link);
    }
}
