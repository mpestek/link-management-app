using BackendArchitecture.Api.Helpers;
using BackendArchitecture.Api.Models;
using BackendArchitecture.Api.Validators;
using BackendArchitecture.Business;
using BackendArchitecture.Entities;
using BackendArchitecture.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackendArchitecture.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("suggest-tags")]
    public class TagSuggestionsController : ControllerBase
    {
        private readonly ILogger<LinksController> _logger;
        private readonly ILinkRepository _linkRepository;
        private readonly IUserUtilities _userUtilities;

        public TagSuggestionsController(
            ILogger<LinksController> logger,
            ILinkRepository linkRepository,
            IUserUtilities userUtilities)
        {
            _logger = logger;
            _linkRepository = linkRepository;
            _userUtilities = userUtilities;
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Get([FromBody]string uri)
        {
            try
            {
                if (!UriValidator.isValid(uri))
                {
                    return BadRequest("Invalid uri.");
                }

                string normalizedUri = new UriHandler(uri).GetNormalizedUri();

                return _linkRepository.GetSuggestedTags(normalizedUri);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }
    }
}
