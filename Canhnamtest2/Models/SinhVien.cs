
using System.ComponentModel.DataAnnotations;

namespace Canhnamtest2.Models{

    public class SinhVien{
        [Key]

        [Display(Name = "Ma sinh vien")]
        [MaxLength (20)]
        public  string MaSinhVien { get; set; }
        
        [Display(Name ="Ho va ten")]
        [MaxLength(50)]

        public string HoTen { get; set; }

        [Display(Name ="Ma lop")]

        public int? MaLop { get; set; }

        public LopHoc? LopHoc{ get; set; }    
    }
}