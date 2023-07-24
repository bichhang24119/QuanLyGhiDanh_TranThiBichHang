using Microsoft.AspNetCore.Identity;

namespace QuanLyGhiDanh.Data
{
    public class User : IdentityUser
    {
        public string FisrtName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
