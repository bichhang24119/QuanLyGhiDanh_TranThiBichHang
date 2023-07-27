using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGhiDanh.Data
{
    [Table("Hocvien")]
    public class Hocvien
    {
        [Key] public int Idhocvien { get; set; }
        public string Hotenhocvien { get; set; }
        public string? Ngaysinh { get; set; }
        public string? Gioitinh { get; set; }
        public string Email { get; set; }
        public string? Diachi { get; set; }
        public string Tenphuhuynh { get; set; }
    }
}
