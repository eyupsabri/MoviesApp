using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using MoviesAppUser.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesAppUser.ActionFilter
{
    public class MyAuthActionFilter : IActionFilter
    {
        private readonly string _secretKey;
        private readonly string _jwtIssuer;


        public MyAuthActionFilter(string secretKey, string jwtIssuer)
        {
            _secretKey = secretKey;
            _jwtIssuer = jwtIssuer;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //if (context.HttpContext.User.Identity is ClaimsIdentity identity)
            //{
            //    var emailClaim = identity.FindFirst(ClaimTypes.Email);
            //    if (emailClaim != null)
            //    {
            //        context.HttpContext.Items["Email"] = emailClaim.Value;
            //    }
            //}
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                //if (ValidateToken(token, out ClaimsPrincipal principal))
                //{
                //    var emailClaim = principal.FindFirst(ClaimTypes.Email);
                //    var tokenTypeClaim = principal.FindFirst("token_type");

                //    if (emailClaim != null && tokenTypeClaim?.Value == "access")
                //    {
                //        context.HttpContext.Items["Email"] = emailClaim.Value;
                //        return;
                //    }
                //}
                var response = TokenHelper.ValidateToken(token, _secretKey, _jwtIssuer);
                if (!response.IsValidToken)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                if (response.IsExpired)
                {
                    if (response.TokenType == "access")
                    {
                        //unauthorized ve refresh token iste
                        context.Result = new ContentResult
                        {
                            StatusCode = 401,
                            Content = "Refresh Token",
                            ContentType = "text/plain",
                        };
                        return;
                    }

                }
                else
                {
                    if (response.TokenType == "access")
                    {
                        context.HttpContext.Items["Email"] = response.Email;
                        return;
                    }

                }
            }

            context.Result = new UnauthorizedResult();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

    }
}

