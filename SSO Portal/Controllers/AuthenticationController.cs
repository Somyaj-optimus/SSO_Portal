using SSO.DataAccessLayer.Constants;
using System.Web.Http;

namespace SSO_Portal.Controllers
{
    public class AuthenticationController : ApiController
    {
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
            return Ok();
        }
    }
}
