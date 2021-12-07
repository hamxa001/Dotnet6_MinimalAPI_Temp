using WebApplication1.EndPointExtension;

namespace WebApplication1.Helpers
{
    public class Session : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.UseCookiePolicy();
            app.UseSession();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}
