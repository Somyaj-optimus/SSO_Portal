using SSO.DataAccessLayer.Constants;
using SSO.DataAccessLayer.Interfaces;
using System;
using System.Diagnostics;
using System.Web.Http;

namespace SSO_Portal.Controllers
{
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
            try
            {
                if (!userId.Equals(null))
                {
                    var list = _user.GetApplications(userId);
                    return Ok(list);
                }
                return BadRequest("Invalid Id");
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
