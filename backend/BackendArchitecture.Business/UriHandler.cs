using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendArchitecture.Business
{
    public class UriHandler : IUriHandler
    {
        private Uri ValidateAndInstantiateUri(string uri)
        {
            Uri validatedUri;

            if (!uri.StartsWith("http"))
            {
                uri = $"{"http://"}{uri}";
            }

            bool succeeded = Uri.TryCreate(uri, UriKind.Absolute, out validatedUri);

            if (!succeeded)
            {
                throw new ArgumentException("Invalid uri.");
            }

            return validatedUri;
        }

        public string GetNormalizedUri(string uri)
        {
            Uri validatedUri = ValidateAndInstantiateUri(uri);

            if (String.IsNullOrEmpty(validatedUri.Query))
            {
                return validatedUri.ToString();
            }

            string query = validatedUri.Query.Trim('?');
            List<string> queryParams = query.Split('&').ToList();

            // Sorting query params so that different order doesn't result in different URIs
            queryParams.Sort();

            string resultingQuery = queryParams.Aggregate((first, second) => $"{first}&{second}");

            return $"{validatedUri.Scheme}://{validatedUri.Host}{validatedUri.LocalPath}?{resultingQuery}";
        }
    }
}
