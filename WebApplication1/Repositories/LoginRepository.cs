using WebApplication1.IRepositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DatabaseDBContext _context;
        public LoginRepository(DatabaseDBContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<string>> Login(LoginInformation Credentials)
        {
            var ServiceResponse = new ServiceResponse<string>();
            try
            {
                var get =  _context.Users.First(x => x.Email == Credentials.Email);
                ServiceResponse.Data = ""; 
                ServiceResponse.Success = true;
                ServiceResponse.Message = "All Roles Successfully Fetched!";
            }
            catch (Exception ex)
            {
                ServiceResponse.Data = string.Empty;
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
    }
}
