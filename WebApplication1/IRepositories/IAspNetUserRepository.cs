using WebApplication1.DTOs.UserDTOs;

namespace WebApplication1.IRepositories
{
    public interface IAspNetUserRepository
    {
        public Task<ServiceResponse<List<AspNetUsers>>> GetAllUsers();
        public Task<ServiceResponse<AspNetUsers>> GetUserByID(string UserID);
        public Task<ServiceResponse<AspNetUsers>> AddUser(AddUserDto Users);
        public Task<ServiceResponse<AspNetUsers>> UpdateUser(string UserID, AspNetUsers Users);
        public Task<ServiceResponse<bool>> DeleteUser(string UserID);
    }
}