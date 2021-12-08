using Microsoft.EntityFrameworkCore;
using WebApplication1.IRepositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AspNetUserRepositories : IAspNetUserRepository
    {
        private readonly DatabaseDBContext _context;
        public AspNetUserRepositories(DatabaseDBContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<AspNetUsers>>> GetAllUsers()
        {
            var ServiceResponse = new ServiceResponse<List<AspNetUsers>>();
            try
            {
                var dbUsers = await _context.Users.ToListAsync();
                ServiceResponse.Data = dbUsers;
                ServiceResponse.Success = true;
                ServiceResponse.Message = "All Users Fetched!";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        public async Task<ServiceResponse<AspNetUsers>> GetUserByID(string UserID)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<AspNetUsers>> AddUser(AspNetUsers Users)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<AspNetUsers>> UpdateUser(string UserID, AspNetUsers Users)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<bool>> DeleteUser(string UserID)
        {
            throw new NotImplementedException();
        }
    }
}
