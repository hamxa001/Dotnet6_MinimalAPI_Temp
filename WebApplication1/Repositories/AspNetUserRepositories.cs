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
            var ServiceResponse = new ServiceResponse<AspNetUsers>();
            try
            {
                var users = await _context.Users.SingleAsync(x => x.Id == UserID);
                ServiceResponse.Data = users;
                ServiceResponse.Success = true;
                ServiceResponse.Message = "User successfully fetched!";
            }
            catch (Exception ex)
            {

                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        public async Task<ServiceResponse<AspNetUsers>> AddUser(AspNetUsers Users)
        {
            var ServiceResponse = new ServiceResponse<AspNetUsers>();
            try
            {
                Users.Id = Guid.NewGuid().ToString();
                var AddUser = await _context.Users.AddAsync(Users);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = await _context.Users.SingleAsync(x => x.Id == Users.Id);
                ServiceResponse.Success = true;
                ServiceResponse.Message = "User successfully added!";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        public async Task<ServiceResponse<AspNetUsers>> UpdateUser(string UserID, AspNetUsers UpdateUsers)
        {
            var ServiceResponse = new ServiceResponse<AspNetUsers>();
            try
            {
                var Users = await _context.Users.FirstOrDefaultAsync(x=>x.Id == UserID);
                Users.UserName = UpdateUsers.UserName;
                Users.AccessFailedCount = UpdateUsers.AccessFailedCount;
                Users.ConcurrencyStamp = UpdateUsers.ConcurrencyStamp;
                Users.Email = UpdateUsers.Email;
                Users.EmailConfirmed = UpdateUsers.EmailConfirmed;
                Users.LockoutEnabled = UpdateUsers.LockoutEnabled;
                Users.LockoutEnd = UpdateUsers.LockoutEnd;
                Users.NormalizedEmail = UpdateUsers.NormalizedEmail;
                Users.NormalizedUserName = UpdateUsers.NormalizedUserName;
                Users.PhoneNumber = UpdateUsers.PhoneNumber;
                Users.PhoneNumberConfirmed = UpdateUsers.PhoneNumberConfirmed;
                Users.SecurityStamp = UpdateUsers.SecurityStamp;
                Users.TwoFactorEnabled = UpdateUsers.TwoFactorEnabled;

                await _context.SaveChangesAsync();

                ServiceResponse.Data = await _context.Users.SingleAsync(x => x.Id == UserID);
                ServiceResponse.Success = true;
                ServiceResponse.Message = "User successfully Updated!";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        public async Task<ServiceResponse<bool>> DeleteUser(string UserID)
        {
            var ServiceResponse = new ServiceResponse<bool>();
            try
            {
                var DeleteUser = await _context.Users.SingleAsync(x => x.Id == UserID);
                _context.Users.Remove(DeleteUser);
                await _context.SaveChangesAsync();

                ServiceResponse.Data = true;
                ServiceResponse.Success = true;
                ServiceResponse.Message = "User successfully Deleted!";
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
