using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MVCMovie.Models;

namespace MvcMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Person> Persons {get; set;}
        public DbSet<Employee> Employee {get; set;}
        public  DbSet<Student> Student {get; set;}
    }
}