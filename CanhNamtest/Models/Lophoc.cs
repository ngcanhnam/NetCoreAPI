

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanhNamtest{

    public class Lophoc{
        [Key]
        [Display(Name = "Ma lop")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Malop { get; set; }

        [Display(Name = "Ten lop")]
        [MaxLength(50)]

        public required string Tenlop { get; set; }
    }
}