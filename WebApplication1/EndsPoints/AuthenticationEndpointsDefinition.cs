using WebApplication1.EndPointExtension;

namespace WebApplication1.EndsPoints
{
    public class AuthenticationEndpointsDefinition : IEndpointDefinition
    {
        private IConfiguration _Configuration { get; }

        public void DefineEndpoints(WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddAuthorization(option =>
            {
                option.FallbackPolicy = new AuthorizationPolicyBuilder()
               .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
               .RequireAuthenticatedUser()
               .Build();
            });
        }
    }
}
