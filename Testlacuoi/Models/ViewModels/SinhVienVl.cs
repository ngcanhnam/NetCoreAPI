using System.ComponentModel.DataAnnotations;

namespace Testlacuoi.Models.ViewModels{

    public class SinhVienVL{

        [Display(Name ="Ho va ten")]
        public string Hoten{ get; set; }

        [Display(Name ="Ma sinh vien")]
        public string MaSinhVien{ get; set; }

        [Display(Name ="Ten Lop")]
        public string TenLop {  get; set; }
        
        [Display(Name ="Mã lớp")]

        public int MaLop {  get; set; }
    }
}