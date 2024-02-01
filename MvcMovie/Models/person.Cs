using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Person")]
    public class Person{
        [Key]

        public string PersonId {get; set;}
        public string fullname {get; set;}
        public string Address {get; set;}
    }
}