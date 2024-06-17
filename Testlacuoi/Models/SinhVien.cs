using System.ComponentModel.DataAnnotations;

namespace Testlacuoi.Models{

    public class SinhVien{
        [Key]

        [Display(Name = "Ma Sinh Vien")]
        [MaxLength(20)]

        public string MaSinhVien { get; set; }

        [Display(Name = "ho va ten")]
        [MaxLength(50)]

        public string Hovaten { get; set;}

        [Display(Name = "Ma Lop")]
        public int? MaLop { get; set;}
    }
}