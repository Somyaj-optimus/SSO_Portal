using SSO.DataAccessLayer.Implementations;
using SSO.DataAccessLayer.Interfaces;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SSO_Portal.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        IAuthenticationService authenticationService = new AuthenticationService();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization.Parameter;
            var principle = authenticationService.AuthenticateJwtToken(token);
            


        }
    }
}