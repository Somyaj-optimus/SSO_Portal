using SSO.DataAccessLayer.Model;
using System.Collections.Generic;

namespace SSO.DataAccessLayer.Interfaces
{
   public interface IUserService
    {
        IList<UserDetailsModel> GetListOfApplication(string userId);
    }
}
