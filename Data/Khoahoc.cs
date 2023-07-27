using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGhiDanh.Data
{
    [Table("Khoahoc")]
    public class Khoahoc
    {
        [Key] public int Idkhoahoc { get; set; }
        public string Tenkhoahoc { get; set; }
    }
}
