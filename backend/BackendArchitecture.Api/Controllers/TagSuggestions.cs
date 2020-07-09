using BackendArchitecture.Api.Helpers;
using BackendArchitecture.Api.Models;
using BackendArchitecture.Api.Validators;
using BackendArchitecture.Api.Validators.Interfaces;
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
        private readonly IUriValidator _uriValidator;
        private readonly IUriHandler _uriHandler;

        public TagSuggestionsController(
            ILogger<LinksController> logger,
            ILinkRepository linkRepository,
            IUserUtilities userUtilities,
            IUriValidator uriValidator,
            IUriHandler uriHandler)
        {
            _logger = logger;
            _linkRepository = linkRepository;
            _userUtilities = userUtilities;
            _uriValidator = uriValidator;
            _uriHandler = uriHandler;
        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Get([FromBody]string uri, [FromQuery]bool isFromAnalysis = true)
        {
            try
            {
                if (!_uriValidator.isValid(uri))
                {
                    return BadRequest("Invalid uri.");
                }

                string normalizedUri = _uriHandler.GetNormalizedUri(uri);

                if (!isFromAnalysis)
                {
                    return _linkRepository.GetSuggestedTags(normalizedUri);
                }

                return _linkRepository.GetSuggestedTagsFromAnalysis(normalizedUri);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }
    }
}
