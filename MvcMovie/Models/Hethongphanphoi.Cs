
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcMovie.Models{
    [Table("Hethongphanphoi")]
    public class Hethongphanphoi{
        [Key]
        public required string HTPPId { get; set; }
        public required string HTPPName { get; set; }

    }
}