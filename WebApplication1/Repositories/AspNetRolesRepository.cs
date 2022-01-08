using Microsoft.AspNetCore.Identity;
using WebApplication1.IRepositories;

namespace WebApplication1.Repositories
{
    public class AspNetRolesRepository : IAspNetRolesRepository
    {
        private readonly DatabaseDBContext _context;
        public AspNetRolesRepository(DatabaseDBContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<IdentityRole>>> GetAllRoles()
        {
            var ServiceResponse = new ServiceResponse<List<IdentityRole>>();
            try
            {
                var dbRoles = await _context.Roles.ToListAsync();
                ServiceResponse.Data = dbRoles;
                ServiceResponse.Success = true;
                ServiceResponse.Message = "All Roles Successfully Fetched!";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
    }
}
