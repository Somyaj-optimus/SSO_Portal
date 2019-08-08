using SSO.DataAccessLayer.Constants;
using SSO.DataAccessLayer.Interfaces;
using SSO_Portal.Filters;
using System;
using System.Diagnostics;
using System.Web.Http;

namespace SSO_Portal.Controllers
{
    [AuthenticationFilter]
    public class UserController : ApiController
    {
        #region Private Field
        private readonly IUserService _user;
        #endregion

        public UserController(IUserService userServices)
        {
            _user = userServices;
        }


        #region ListOfApplication 
        /// <summary>
        /// To find the list of Application
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IHttpActionResult ListOfApplication(string userId)
        {
            Request.Properties.TryGetValue("userId", out object userid);

            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    return NotFound();
                }
                var applications = _user.GetApplications(userId);
                if (applications.Count > 0)
                {
                    return Ok(applications);
                }
                return NotFound();

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
