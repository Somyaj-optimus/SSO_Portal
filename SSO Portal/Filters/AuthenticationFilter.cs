using Microsoft.IdentityModel.Tokens;
using static SSO.DataAccessLayer.Constants.ApiConstant;
using SSO.DataAccessLayer.Implementations;
using SSO.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace SSO_Portal.Filters
{
    /// <summary>
    /// Custom filter created for authenticatication purpose
    /// </summary>
    public class AuthenticationFilter : ActionFilterAttribute
    {

        IAuthenticationService authenticationService = new AuthenticationService();

        /// <summary>
        /// On Action Executing
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string userId;
            var token = actionContext.Request.Headers.Authorization.Parameter;
            var tokenHandler = new JwtSecurityTokenHandler();
            if (!IsAuthorize(token))
            {
                actionContext.Response = new HttpResponseMessage
                {
                    Content = new StringContent(InvalidToken)
                };
            }
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            IList<Claim> claims = jwtToken.Claims.ToList();
            userId = claims[0].Value;
            actionContext.Request.Properties.Add(UserId,userId);
        }
         
        /// <summary>
        /// To check Authorization
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool IsAuthorize(string token)
        {
           bool result = false;
            try
            {
                var validationParameters = GetValidationParameters();
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return true;
            }
            catch(Exception ex)
            {
                return result;
            }
        }

        /// <summary>
        /// Get token Validation Parameters
        /// </summary>
        /// <returns></returns>
        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, 
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)) // The same key as the one that generate the token
            };
        }
    }
}