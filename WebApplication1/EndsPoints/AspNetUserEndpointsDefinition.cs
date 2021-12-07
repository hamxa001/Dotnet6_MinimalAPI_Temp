using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.EndPointExtension;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.EndsPoints
{
    public class AspNetUserEndpointsDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/register", [AllowAnonymous] async (IdentityUser users) =>
            {
                using (var _context = new DatabaseDBContext())
                {
                    users.Id = Guid.NewGuid().ToString();
                    users.ConcurrencyStamp = Guid.NewGuid().ToString();
                    users.SecurityStamp = Guid.NewGuid().ToString();
                    await _context.AddAsync(users);
                    await _context.SaveChangesAsync();
                }
                return "User successfully created";
            });
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<AspNetUserRepositories>();
        }
    }
}
