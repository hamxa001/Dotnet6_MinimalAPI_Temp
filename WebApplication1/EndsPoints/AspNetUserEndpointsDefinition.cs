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
                if (result.Success)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound(result);
            });

            app.MapGet("/register/{Id}", async Task<IResult> ([FromServices] IAspNetUserRepository _context, string UserId) =>
            {
                var result = await _context.GetUserByID(UserId);
                if (result.Success)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound(result);
            });

            app.MapPost("/register", async Task<IResult> ([FromServices] IAspNetUserRepository _context, [FromBody] AspNetUsers users) => 
            {
                var result = await _context.AddUser(users);
                if (result.Success)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound(result);
            });

            app.MapPut("/register/{Id}", async Task<IResult> ([FromServices] IAspNetUserRepository _context, string Id, [FromBody] AspNetUsers users) =>
            {
                var result = await _context.UpdateUser(Id, users);
                if (result.Success)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound(result);
            });

            app.MapDelete("/register/{Id}", async Task<IResult> ([FromServices] IAspNetUserRepository _context, string UserId) =>
            {
                var result = await _context.DeleteUser(UserId);
                if (result.Success)
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