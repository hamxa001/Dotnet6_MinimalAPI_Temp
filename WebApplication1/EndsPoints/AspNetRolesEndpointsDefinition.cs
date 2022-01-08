using Microsoft.AspNetCore.Identity;
using WebApplication1.EndPointExtension;
using WebApplication1.IRepositories;
using WebApplication1.Repositories;

namespace WebApplication1.EndsPoints
{
    public class AspNetRolesEndpointsDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/Roles", [HttpGet]
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async Task<IResult> ([FromServices] IAspNetRolesRepository _context) =>
             {
                 var result = await _context.GetAllRoles();
                 if (result.Success)
                 {
                     return Results.Ok(result);
                 }
                 return Results.NotFound(result);
             }).Produces<IdentityRole>().RequireAuthorization();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IAspNetRolesRepository, AspNetRolesRepository>();
        }
    }
}
