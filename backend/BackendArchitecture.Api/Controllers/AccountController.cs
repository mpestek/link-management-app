using BackendArchitecture.Api.Helpers;
using BackendArchitecture.Api.Models;
using BackendArchitecture.Entities;
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
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserUtilities _userUtilities;

        public AccountController(
            ILogger<AccountController> logger,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserUtilities userUtilities)
        {                                         
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _userUtilities = userUtilities;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserInfo loginUserInfo)
        {
            try
            {
                 var user = await _userManager.FindByNameAsync(loginUserInfo.Username);

                var signInResult = await _signInManager.PasswordSignInAsync(user, loginUserInfo.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return Ok();
                }

                return BadRequest("Login attempt failed.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserInfo registerUserInfo)
        {
            try
            {
                if (registerUserInfo.Password != registerUserInfo.ConfirmPassword)
                {
                    return BadRequest("Password confirmation doesn't match.");
                }

                var user = new User {
                    UserName = registerUserInfo.Username,
                    Email = registerUserInfo.Email,
                    FirstName = registerUserInfo.FirstName,
                    LastName = registerUserInfo.LastName
                };

                var registrationResult = await _userManager.CreateAsync(user, registerUserInfo.Password);

                if (registrationResult.Succeeded)
                {
                    await _signInManager.PasswordSignInAsync(user, registerUserInfo.Password, false, false);

                    return Ok();
                }

                return BadRequest(registrationResult.Errors
                    .Select(error => error.Description)
                    .Aggregate((prev, next) => prev + '\n' + next));
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("userinfo")]
        public ActionResult<UserInfo> GetUserInfo()
        {
            try
            {
                return _userUtilities.GetUserInfo(HttpContext.User);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                return StatusCode(500);
            }
        }
    }
}
