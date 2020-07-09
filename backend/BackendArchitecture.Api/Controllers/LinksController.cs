using BackendArchitecture.Api.Helpers;
using BackendArchitecture.Api.Models;
using BackendArchitecture.Api.Validators;
using BackendArchitecture.Api.Validators.Interfaces;
using BackendArchitecture.Business;
using BackendArchitecture.Business.Interfaces;
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
    [Route("links")]
    public class LinksController : ControllerBase
    {
        private readonly ILogger<LinksController> _logger;
        private readonly ILinkRepository _linkRepository;
        private readonly IUserUtilities _userUtilities;
        private readonly ILinkValidator _linkValidator;
        private readonly IUriHandler _uriHandler;
        private readonly IUriAnalyzer _uriAnalyzer;

        public LinksController(
            ILogger<LinksController> logger,
            ILinkRepository linkRepository,
            IUserUtilities userUtilities,
            ILinkValidator linkValidator,
            IUriHandler uriHandler,
            IUriAnalyzer uriAnalyzer)
        {
            _logger = logger;
            _linkRepository = linkRepository;
            _userUtilities = userUtilities;
            _linkValidator = linkValidator;
            _uriHandler = uriHandler;
            _uriAnalyzer = uriAnalyzer;
        }

        [HttpGet(Name = "Link")]
        public ActionResult<IEnumerable<Link>> GetAll()
        {
            try
            {
                var userInfo = GetUserInfo();

                return _linkRepository.GetLinksForUser(userInfo.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Link>>> Post([FromBody] Link link)
        {
            try
            {
                if (!_linkValidator.isValid(link))
                {
                    return BadRequest(@"
                        Invalid Link specified!
                        Check that the Uri is valid and that the link contains at least one tag!
                    ");
                }

                var userInfo = GetUserInfo();

                link.UserId = userInfo.Id;
                link.Uri = _uriHandler.GetNormalizedUri(link.Uri);

                link.AnalysisTagResults = await _uriAnalyzer.AnalyzeKeywordOcurrences(link.Uri);
                
                var createdLink = _linkRepository.Create(link);

                return CreatedAtRoute("Link", new { id = createdLink.Id }, createdLink);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        private UserInfo GetUserInfo()
        {
            return _userUtilities.GetUserInfo(HttpContext.User);
        }
    }
}
