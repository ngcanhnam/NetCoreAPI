
using NewApp.Models;

    public class Student : Person
    {
        public string StudentCode {get;set;}
        public void EnterData(){
            base.EnterData();
            System.Console.Write("Student Code = ");
            StudentCode = Console.ReadLine();
        }
        public void Display(){
            base.Display();
            System.Console.Write("-ma sinh vien: {0}", StudentCode);
         }
    }
