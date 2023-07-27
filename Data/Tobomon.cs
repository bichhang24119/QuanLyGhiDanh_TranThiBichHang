using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGhiDanh.Data
{
    [Table ("Tobomon")]
    public class Tobomon
    {
        [Key] public int Idtobomon { get; set; }
        public string? TenToBoMon { get; set; }
    }
}
