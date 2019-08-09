using Newtonsoft.Json;
using SSO.DataAccessLayer.Interfaces;
using SSO.DataAccessLayer.Model;
using System.Collections.Generic;
using System.Net.Http;
using static SSO.DataAccessLayer.Constants.ApiConstant;

namespace SSO.DataAccessLayer.Implementations
{
    public class UserService : IUserService
    {
        #region Private Fields

        private readonly HttpClient _client = new HttpClient();

        #endregion

        #region Public methods
        /// <summary>
        /// To get the list of the Applications
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<Application> GetApplications(string userId)
        {
            string url = $"{OrganizationDomain}/api/v1/users/{userId}/appLinks";
            _client.DefaultRequestHeaders.Add(Authorization, SSWS + SSWSToken);
            var response = _client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var applications = JsonConvert.DeserializeObject<List<Application>>(json);
                return applications;
            }
            return new List<Application>();
        }

        /// <summary>
        /// Fetch user id from Access token
        /// </summary>
        /// <param name="oktaAccessToken">okta access token</param>
        /// <returns> User id</returns>
        public string GetUserId(string oktaAccessToken)
        {
            string userInfoApi = $"{OrganizationDomain}{UserInfo}";
            _client.DefaultRequestHeaders.Add(Authorization, Bearer + oktaAccessToken);
            var response = _client.GetAsync(userInfoApi).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(content);
                return user.Id;
            }
            return null;
        }
        #endregion

    }
}

