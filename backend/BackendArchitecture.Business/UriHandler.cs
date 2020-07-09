using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendArchitecture.Business
{
    public class UriHandler
    {
        private readonly Uri _uri;

        public UriHandler(string uri)
        {
            _uri = ValidateAndInstantiateUri(uri);
        }

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

        public string GetNormalizedUri()
        {
            if (String.IsNullOrEmpty(_uri.Query))
            {
                return _uri.ToString();
            }

            string query = _uri.Query.Trim('?');
            List<string> queryParams = query.Split('&').ToList();

            queryParams.Sort();

            string resultingQuery = queryParams.Aggregate((first, second) => $"{first}&{second}");

            return $"{_uri.Scheme}://{_uri.Host}{_uri.LocalPath}?{resultingQuery}";
        }
    }
}
