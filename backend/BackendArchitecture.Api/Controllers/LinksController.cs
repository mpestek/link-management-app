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
    [Route("links")]
    public class LinksController : ControllerBase
    {
        private readonly ILogger<LinksController> _logger;
        private readonly ILinkRepository _linkRepository;
        private readonly IUserUtilities _userUtilities;

        public LinksController(
            ILogger<LinksController> logger,
            ILinkRepository linkRepository,
            IUserUtilities userUtilities)
        {
            _logger = logger;
            _linkRepository = linkRepository;
            _userUtilities = userUtilities;
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
        public ActionResult<IEnumerable<Link>> Post([FromBody] Link link)
        {
            try
            {
                if (!UriValidator.isValid(link.Uri))
                {
                    return BadRequest("Invalid Uri specified");
                }

                var userInfo = GetUserInfo();

                link.UserId = userInfo.Id;
                link.Uri = new UriHandler(link.Uri).GetNormalizedUri();

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
