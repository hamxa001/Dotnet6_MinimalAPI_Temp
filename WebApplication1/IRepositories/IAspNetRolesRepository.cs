using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.IRepositories
{
    public interface IAspNetRolesRepository
    {
        public Task<ServiceResponse<List<IdentityRole>>> GetAllRoles();
    }
}
