using System.Dynamic;

namespace NewApp.Models
{
    public class Person{
        public string fullname {get; set;}
        public string Adress {get;set;}
        public int Age {get;set;}

        public void EnterData(){
            System.Console.Write("full name = ");
            fullname = Console.ReadLine();
            System.Console.Write("Address = ");
            Adress = Console.ReadLine();
            System.Console.Write("Age = ");
            Age = Convert.ToInt16(Console.ReadLine());
        }
        public void Display(){
            System.Console.WriteLine("{0} - {1} - {2} tuoi ", fullname, Adress, Age);
        }
    }
}