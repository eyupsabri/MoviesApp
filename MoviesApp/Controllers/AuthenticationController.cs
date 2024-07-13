using Azure;
using Business.Services;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesAppUser.ActionFilter;
using MoviesAppUser.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesAppUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private IConfiguration _config;
        private IUserService _userService;

        public AuthenticationController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public IActionResult SignUp([FromBody] UserModel user)
        {
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = await _userService.AuthenticateUser(login.Email, login.Password);
            if (user != null)
            {
                var jwtIssuer = _config.GetSection("Jwt:Issuer").Get<string>();
                var jwtKey = _config.GetSection("Jwt:Key").Get<string>();

                var accessToken = TokenHelper.GenerateToken(user.Email, false, jwtKey, jwtIssuer);
                var refreshToken = TokenHelper.GenerateToken(user.Email, true, jwtKey, jwtIssuer);
                var isAdmin = user.IsAdmin;
                response = Ok(new { accessToken = accessToken, refreshToken = refreshToken, isAdmin = isAdmin });
            }

            return response;
        }

        [HttpGet]
        [ServiceFilter(typeof(MyAuthActionFilter))]
        [Route("[action]")]
        public async Task<IActionResult> IsLoggedIn()
        {
            if (HttpContext.Items.ContainsKey("Email"))
            {
                // Retrieve the email from HttpContext.Items
                var email = HttpContext.Items["Email"] as string;

                // Use the email as needed
                if (!string.IsNullOrEmpty(email))
                {
                    var user = await _userService.GetUserByEmail(email);
                    var isAdmin = user.IsAdmin;
                    return Ok(new { isAdmin = isAdmin });
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> RefreshToken(string token)
        {
            var jwtIssuer = _config.GetSection("Jwt:Issuer").Get<string>();
            var jwtKey = _config.GetSection("Jwt:Key").Get<string>();
            var response = TokenHelper.ValidateToken(token, jwtKey, jwtIssuer);
            if (response.IsValidToken && !response.IsExpired && response.TokenType == "refresh")
            {
                var accessToken = TokenHelper.GenerateToken(response.Email, false, jwtKey, jwtIssuer);
                var refreshToken = TokenHelper.GenerateToken(response.Email, true, jwtKey, jwtIssuer);
                var user = await _userService.GetUserByEmail(response.Email);
                var isAdmin = user.IsAdmin; 
                return Ok(new { accessToken = accessToken, refreshToken = refreshToken, isAdmin = isAdmin });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {

            return Ok();
        }
    

    }
}
