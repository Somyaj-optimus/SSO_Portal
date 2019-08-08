using System.Security.Claims;

namespace SSO.DataAccessLayer.Interfaces
{
   public interface IAuthenticationService
    {
        string GenerateToken(string userId);
        ClaimsPrincipal AuthenticateJwtToken(string token);
    }
}
