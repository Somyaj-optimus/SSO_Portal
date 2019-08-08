using Microsoft.IdentityModel.Tokens;
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
    public class AuthenticationFilter : ActionFilterAttribute
    {
        #region Private Field
        private const string secret = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        #endregion

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
                    Content = new StringContent("Invalid userId")
                };
            }
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            IList<Claim> claims = jwtToken.Claims.ToList();
            userId = claims[0].Value;
            actionContext.Request.Properties.Add("userId",userId);
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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)) // The same key as the one that generate the token
            };
        }
    }
}