using System;
using System.Collections.Generic;
using System.Text;

namespace BackendArchitecture.Business
{
    public interface IUriHandler
    {
        string GetNormalizedUri(string uri);
    }
}
