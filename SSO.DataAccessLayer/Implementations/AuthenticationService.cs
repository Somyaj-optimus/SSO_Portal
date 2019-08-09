using SSO.DataAccessLayer.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static SSO.DataAccessLayer.Constants.ApiConstant;

namespace SSO.DataAccessLayer.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {

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

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(Secret));
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
