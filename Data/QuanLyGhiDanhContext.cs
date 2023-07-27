using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyGhiDanh.Data;

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
        public DbSet<QuanLyGhiDanh.Data.Khoahoc> Khoahoc { get; set; } = default!;
        public DbSet<QuanLyGhiDanh.Data.Lophoc> Lophoc { get; set; } = default!;
        public DbSet<QuanLyGhiDanh.Data.Monhoc> Monhoc { get; set; } = default!;
        public DbSet<QuanLyGhiDanh.Data.Tobomon> Tobomon { get; set; } = default!;
        #endregion
    }
}
