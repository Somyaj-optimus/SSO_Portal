using System.Configuration;

namespace SSO.DataAccessLayer.Constants
{
    /// <summary>
    /// Handle all constants
    /// </summary>
    public static class ApiConstant
    {
        #region Okta Constants
        // Okta organization domain
        public readonly static string OrganizationDomain = ConfigurationManager.AppSettings["OktaDomain"];

        // Okta SSWS token
        public readonly static string SSWSToken = ConfigurationManager.AppSettings["SSWSToken"];

        //api to fetch user information from access token
        public const string UserInfo = "/oauth2/v1/userinfo";

        #endregion

        #region Error Message

        public const string ArgumentNull = "Please provide an user id";
        public const string SomethingWrong = "Something went wrong";

        #endregion

        #region Common
        public const string Authorization = "Authorization";
        public const string Bearer = "Bearer";
        public const string SSWS = "SSWS";
        #endregion
    }
}
