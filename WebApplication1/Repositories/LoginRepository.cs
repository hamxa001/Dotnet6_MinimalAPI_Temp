using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApplication1.IRepositories;
using WebApplication1.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplication1.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DatabaseDBContext _context;
        private readonly IConfiguration _configuration;

        public LoginRepository(DatabaseDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> Login(LoginInformation Credentials)
        {
            var ServiceResponse = new ServiceResponse<string>();
            try
            {
                var User = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == Credentials.Email.ToLower());
                                
                if(User == null){
                ServiceResponse.Success = false;
                ServiceResponse.Message = "User not found.";
                }
                else
                if(!VerifyPasswordHash(Credentials.Password, Convert.FromBase64String(User.PasswordHash), User.PasswordSalt))
                {
                    ServiceResponse.Success = false;
                    ServiceResponse.Message = "Username Or Password Is Incorrect";
                }
                else{
                    ServiceResponse.Data = CreateToken(User); 
                    ServiceResponse.Success = true;
                    ServiceResponse.Message = "Login is Successfull!";
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.Data = string.Empty;
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(AspNetUsers users)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, users.Id), 
                new Claim(ClaimTypes.Name, users.UserName),
                new Claim(ClaimTypes.Email, users.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
