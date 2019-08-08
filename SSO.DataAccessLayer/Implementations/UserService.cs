using Newtonsoft.Json;
using SSO.DataAccessLayer.Interfaces;
using SSO.DataAccessLayer.Model;
using System.Collections.Generic;
using System.Net.Http;

namespace SSO.DataAccessLayer.Implementations
{
    public class UserService : IUserService
    {
        #region Private Fields

        private readonly string token = "00aV-lNOo6y5DkdFfBH7CDuNKxj5OIc4Mw-PM_D_VV";

        #endregion

        #region Public methods
        /// <summary>
        /// To get the list of the Applications
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<UserDetailsModel> GetListOfApplication(string userId)
        {
            string url = $"https://optimusinfo-deepaknegi.okta.com/api/v1/users/{userId}/appLinks";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization","SSWS " +token);
            var GetRequestResponse = client.GetAsync(url).Result;
            var json = GetRequestResponse.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<UserDetailsModel>>(json);
            return value;
        }
        #endregion

    }
}

