
namespace SSO.DataAccessLayer.Interfaces
{
   public interface IAuthenticationService
    {
        string GenerateToken(string userId);
    }
}
