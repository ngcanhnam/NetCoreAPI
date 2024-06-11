
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcMovie.Models{
    [Table("Students")]
    public class Student{
        [Key]
        public required string StudentId { get; set; } 
        public required string StudentName {get; set;}
        public required string Address {get; set;}

        public required int Age {get; set;}

        public required  string Email {get; set;}    
        
    }
}