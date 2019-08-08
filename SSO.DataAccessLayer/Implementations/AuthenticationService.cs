using SSO.DataAccessLayer.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SSO.DataAccessLayer.Implementations
{
    public class AuthenticationService : IAuthenticationService

    {
        #region Private Field
        private const string secret = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        #endregion

        #region Public methods
        /// <summary>
        /// To generate JWT Token
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GenerateToken(string userId)
        {
            var claimData = new[]
            {
                new Claim(ClaimTypes.Name, userId)
            };

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secret));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken
            (
               issuer: "no",
               audience: "no",
               claims: claimData,
               expires: DateTime.Now.AddDays(1),
               signingCredentials: signingCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        #endregion
    }
}
