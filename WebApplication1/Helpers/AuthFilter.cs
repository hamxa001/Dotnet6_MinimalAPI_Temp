using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Helpers
{
    public class AuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var a = context.HttpContext.User.Claims;
            

            //throw new NotImplementedException();
        }
    }
}
