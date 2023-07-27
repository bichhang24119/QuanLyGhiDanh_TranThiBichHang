using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGhiDanh.Data
{
    [Table ("Lophoc")]
    public class Lophoc
    {
        [Key] public int Idlophoc { get; set; }
        public string Tenlop { get; set; }
        public string Monhoc { get; set; }
        public string Giangvienphutrach { get; set; }
        public string Ngayhoc { get; set; }
        public string Giohoc { get; set; }
        public string Batdauketthuc { get; set; }
        public int Hocphi { get; set; }
    }
}
