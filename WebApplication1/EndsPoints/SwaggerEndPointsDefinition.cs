using Microsoft.OpenApi.Models;
using WebApplication1.EndPointExtension;

namespace WebApplication1.EndsPoints
{
    public class SwaggerEndPointsDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet Minimal Api v1");
            });
        }
        public void DefineServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dotnet Minimal Api", Version = "v1" });
            });
        }
    }
}
