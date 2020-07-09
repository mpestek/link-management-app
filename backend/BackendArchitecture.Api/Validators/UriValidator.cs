using BackendArchitecture.Api.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Validators
{
    public class UriValidator : IUriValidator
    {
        public bool isValid(string uri)
        {
            Uri validatedUri;

            if (!uri.StartsWith("http"))
            {
                uri = $"{"http://"}{uri}";
            }

            return Uri.TryCreate(uri, UriKind.Absolute, out validatedUri);
        }
    }
}
