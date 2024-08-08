using Microsoft.AspNetCore.Identity;

namespace Q3DotNetAssiut.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }

    }
}
