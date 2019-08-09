using SSO.DataAccessLayer.Model;
using System.Collections.Generic;

namespace SSO.DataAccessLayer.Interfaces
{
    public interface IUserService
    {
        IList<Application> GetApplications(string userId);
        string GetUserId(string oktaAccessToken);
    }
}
