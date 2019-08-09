using SSO.DataAccessLayer.Constants;
using SSO.DataAccessLayer.Interfaces;
using System;
using System.Diagnostics;
using System.Web.Http;

namespace SSO_Portal.Controllers
{
    public class AuthenticationController : ApiController
    {
        #region Private Fields
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        #endregion

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        #region Public Methods
        /// <summary>
        /// Create and return JWT token for an access token
        /// </summary>
        /// <param name="accessToken">access token</param>
        /// <returns>JWT</returns>
        [HttpGet]
        public IHttpActionResult GetAuthenticationToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                return BadRequest(ApiConstant.ArgumentNull);
            try
            {
                string userId = _userService.GetUserId(accessToken);
                if (string.IsNullOrWhiteSpace(userId))
                    return Unauthorized();//Access token expired or invalid

                string jwtToken = _authenticationService.GenerateToken(userId);
                return Ok(jwtToken);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                return BadRequest(ApiConstant.SomethingWrong);
            }
        }
        #endregion
    }
}
