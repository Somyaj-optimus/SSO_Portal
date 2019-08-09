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

        public const string ArgumentNull = "Please provide an access token";
        public const string SomethingWrong = "Something went wrong";

        #endregion

        #region Common
        public const string Authorization = "Authorization";
        public const string Bearer = "Bearer ";
        public const string SSWS = "SSWS ";
        public const string InvalidToken = "Invalid Token";
        public const string UserId = "userId";
        public const string Secret = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        #endregion
    }
}
