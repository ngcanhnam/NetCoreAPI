


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canhnamtest2.Models{
    public class LopHoc{
        [Key]
        [Display(Name = "Ma Lop")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLop { get; set; }

        [Display(Name = "Ten Lop")]
        [MaxLength(50)]

        public required string TenLop {get; set;}

        public ICollection<SinhVien>? SinhVien {get; set;}
    }
}