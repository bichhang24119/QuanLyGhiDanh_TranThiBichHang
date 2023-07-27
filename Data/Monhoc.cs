using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGhiDanh.Data
{
    [Table("Monhoc")]
    public class Monhoc
    {
        [Key] public int Idmonhoc { get; set; }
        public string Tenmon { get; set; }
        public string Tobomon { get; set; }
        public string Khoa { get; set; }
    }
}
