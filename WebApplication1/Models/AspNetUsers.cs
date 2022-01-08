using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class AspNetUsers : IdentityUser
    {
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[0];

    }
}
