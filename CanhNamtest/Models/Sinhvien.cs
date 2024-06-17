
using System.ComponentModel.DataAnnotations;

namespace CanhNamtest{
    public class Sinhvien{
        [Key]

        [Display(Name = "Ma Sinh vien")]
        [MaxLength(20)]

        public required string Masinhvien { get; set; }

        [Display(Name ="Ho va ten")]

        [MaxLength(50)]
        public required string Hoten { get; set; }
        
        [Display(Name ="Ma lop")]

        public int Malop { get; set; }

    }
}