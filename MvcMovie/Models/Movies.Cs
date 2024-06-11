using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace MVCMovie.Models;

public class Movie{
    [Key]
    public int Id {get;set;}
    public string? Title {get;set;}
    [DataType(DataType.Date)]
    public DateTime ReleaseDate{get;set;}
    public string? Genre {get;set;}
    public decimal Price {get;set;}
}