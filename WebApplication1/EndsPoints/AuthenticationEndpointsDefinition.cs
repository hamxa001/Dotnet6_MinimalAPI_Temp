using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1.EndPointExtension;

namespace WebApplication1.EndsPoints
{
    public class AuthenticationEndpointsDefinition : IEndpointDefinition
    {
        public IConfiguration Configuration { get;}
        public void DefineEndpoints(WebApplication app)
        {
          
        }

        public void DefineServices(IServiceCollection services)
        {
            
        }
    }
}
