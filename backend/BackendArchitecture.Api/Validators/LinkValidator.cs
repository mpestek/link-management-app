using BackendArchitecture.Api.Validators.Interfaces;
using BackendArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Validators
{
    public class LinkValidator : ILinkValidator
    {
        private readonly IUriValidator _uriValidator;
        public LinkValidator(IUriValidator uriValidator)
        {
            _uriValidator = uriValidator;
        }

        public bool isValid(Link link)
        {
            return _uriValidator.isValid(link.Uri) && link.Tags.Count > 0;
        }
    }
}
