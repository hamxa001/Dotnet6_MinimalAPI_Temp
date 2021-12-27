using WebApplication1.EndPointExtension;
using WebApplication1.IRepositories;
using WebApplication1.Repositories;

namespace WebApplication1.EndsPoints
{
    public class LoginEndpointsDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
        }
    }
}
