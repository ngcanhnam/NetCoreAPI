
using System.ComponentModel.DataAnnotations;

namespace CanhNamtest.Models.ViewModels{

    public class SinhvienVm{
    [Display(Name= "Ma lop")]
    public int Malop { get; set; }

    [Display(Name= "Ten lop")]

    public required string Tenlop { get; set; }

    [Display(Name ="Ma sinh vien")]
    
    public required string Masinhvien { get; set; }

    [Display(Name ="Ho va ten ")]

    public required string Hovaten { get; set; }
}
}