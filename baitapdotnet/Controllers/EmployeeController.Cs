using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace  MvcMovie.Controllers{
     public class EmployeeControler : Controller{
        public IActionResult Index(){
            return View();
     }
     [HttpPost]
        public IActionResult Index(Employee ps)
        {
            string strOutput = "xin chào" + ps.EmployeeId + "với số tuổi" + ps.Age;
            ViewBag.infoEmployee = strOutput;
            return View();
        }
    
}
}