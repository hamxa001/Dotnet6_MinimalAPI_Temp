using Microsoft.AspNetCore.Identity;

namespace WebApplication1.IRepositories
{
    public interface IAspNetRolesRepository
    {
        public Task<ServiceResponse<List<IdentityRole>>> GetAllRoles();
    }
}
