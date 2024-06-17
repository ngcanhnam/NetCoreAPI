
using System.ComponentModel.DataAnnotations;

namespace NCN_2121050710_2324.Models{

    public class Employee{
        [Key]

        [Display(Name ="Ho ten")]
        public string HotenEmployee { get; set; }
        [Display(Name = "Age")]

        public int Age { get; set; }

        [Display(Name = "Ma Employee")]

        public string MaEmployee { get; set; }  
        [Display (Name = "LopEmployee")]
        public string LopEmployee { get; set; }
        
    }
}