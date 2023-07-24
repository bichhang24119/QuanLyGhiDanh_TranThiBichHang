using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGhiDanh.Data
{
    [Table("Giangvien")]
    public class Giangvien
    {
        [Key] public int Idgiangvien { get; set; }
        public double Masothue { get; set; }
        public string Hotengiangvien { get; set; }
        public string? Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Email { get; set; }
        public string Sodienthoai { get; set; }
        public string? Diachi { get; set; }
        public string Mongiangday { get; set; }
    }
}
