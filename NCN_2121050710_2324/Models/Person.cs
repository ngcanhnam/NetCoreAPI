
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace NCN_2121050710_2324{
        public class Person{
            [Key]
        
        [Display (Name ="Ho va ten sinh vien")]
        

        public string HoTen { get; set; }

        [Display (Name ="MaSinhVien")]
        public string MaSinhVien { get; set; }

        [Display (Name ="Ngay sinh")]

        public int Tuoi { get; set; }

        [Display(Name ="Lop hoc sinh vien")]
        public string TenLop { get; set; }
    }
}