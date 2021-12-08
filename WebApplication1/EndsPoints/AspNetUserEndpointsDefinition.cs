using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.EndPointExtension;
using WebApplication1.IRepositories;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.EndsPoints
{
    public class AspNetUserEndpointsDefinition : IEndpointDefinition
    {
              
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/register", async Task<IResult> ([FromServices] IAspNetUserRepository _context) =>
            {
                var result = await _context.GetAllUsers();
                if(result.Success)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound(result);
            });
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IAspNetUserRepository,AspNetUserRepositories>();
        }
    }
}
