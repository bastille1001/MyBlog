using Microsoft.AspNetCore.Identity;

namespace MyBlog.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
