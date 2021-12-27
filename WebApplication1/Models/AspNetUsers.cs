using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AspNetUsers : IdentityUser
    {
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[0];

    }
}
