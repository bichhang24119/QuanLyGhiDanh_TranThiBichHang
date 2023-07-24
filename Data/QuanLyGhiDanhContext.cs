using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuanLyGhiDanh.Data
{
    public class QuanLyGhiDanhContext : IdentityDbContext<User>
    {
        public QuanLyGhiDanhContext(DbContextOptions<QuanLyGhiDanhContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Hocvien>? Hocviens { get; set; }
        public DbSet<Giangvien>? Giangviens { get; set; }
        #endregion
    }
}
