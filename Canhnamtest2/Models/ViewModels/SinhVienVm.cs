

using System.ComponentModel.DataAnnotations;

namespace Canhnamtest2.Models.ViewModels{
    public class SinhVienVm{
        [Display(Name = "Ma lop")]
        public int? MaLop { get; set; }
        [Display(Name = "Ten Lop")]

        public required string TenLop { get; set; }

        [Display(Name ="Ma Sinh Vien")]

        public required string MaSinhVien { get; set; }

        [Display(Name ="Ho va ten ")]

        public required string HoTen { get; set; }
    }
}