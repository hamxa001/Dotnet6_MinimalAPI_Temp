using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using WebApplication1.EndPointExtension;
using WebApplication1.IRepositories;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.EndsPoints
{
    public class LoginEndpointsDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/login", async Task<IResult> ([FromServices] ILoginRepository _context, [FromBody] LoginInformation login) =>
            {
                var result = await _context.Login(login);
                if (result.Success)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound(result);
            });
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
        }
    }
}
